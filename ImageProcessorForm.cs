using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab01
{
    public partial class ImageProcessorForm : Form
    {
        private const int MAX_PARALLELISATION_LEVEL = -1;

        public event EventHandler ProcessingBegin;
        //public event EventHandler ProcessingCancel;
        public event EventHandler<ProcessingEndEventArgs> ProcessingEnd;
        public event EventHandler AddingFileToListBegin;
        public event EventHandler AddingFileToListEnd;
        public event EventHandler ClearingFilesListBegin;
        public event EventHandler ClearingFilesListEnd;

        public int LastProcessedFilesCount { get; private set; }
        public int LastSuccessfullyProcessedFilesCount { get; private set; }
        public long LastProcessingDeltaTime { get; private set; }
        public long LastProcessingBeginTime { get; private set; }

        public ParallelProcessing parallelProcessor;
        public CancellationTokenSource CancellationInvoker;

        private void EnableConfigControls(object sender, EventArgs e)
        {
            preprocessingConfigPanel.Enabled = true;
            btnStart.Enabled = true;
            numNewPixelSize.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void DisableConfigControls(object sender, EventArgs e)
        {
            preprocessingConfigPanel.Enabled = false;
            btnStart.Enabled = false;
            numNewPixelSize.Enabled = false;
            btnCancel.Enabled = true;
        }

        public ImageProcessorForm()
        {
            InitializeComponent();
            EnableConfigControls(this, null);
            parallelProcessor = new ParallelProcessing();

            txtLogDest.Text = logDestinationFolderDialog.SelectedPath;

            EventHandler<ProcessingEndEventArgs> showAfterStats = (o, e) =>
                MessageBox.Show($"Processing result:\n{e.ProcessedFilesCount} out of {e.RequestedFilesCount} files were processed\n{e.DeltaTime.TotalMilliseconds} ms elapsed", "Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProcessingEnd += showAfterStats;
            ProcessingBegin += DisableConfigControls;
            ProcessingEnd += EnableConfigControls;
            AddingFileToListBegin += DisableConfigControls;
            AddingFileToListEnd += EnableConfigControls;
            ClearingFilesListBegin += DisableConfigControls;
            ClearingFilesListEnd += EnableConfigControls;
        }

        private async void OnStartProcessing(object sender, EventArgs e)
        {
            var logFile = await OpenLogStream(txtLogDest.Text);
            var beginTime = DateTime.Now;

            ProcessingBegin?.Invoke(this, null);
            CancellationInvoker = new CancellationTokenSource();

            var guiThread = Thread.CurrentThread.ManagedThreadId;
            int processingTaskThread = -1;

            string[] filesToProcess = new string[imageList.Images.Keys.Count];
            imageList.Images.Keys.CopyTo(filesToProcess, 0);

            await Task.Run(() =>
            {
                processingTaskThread = Thread.CurrentThread.ManagedThreadId;
                try
                {
                    var token = CancellationInvoker.Token;
                        
                    if (cbParallel.Checked)
                    {
                        parallelProcessor.ProcessImagesInParallel(filesToProcess, (int)numNewPixelSize.Value, MAX_PARALLELISATION_LEVEL, token);
                    }
                    else
                    {
                        parallelProcessor.ProcessImages(filesToProcess, (int)numNewPixelSize.Value, token);
                    }
                }
                catch (OperationCanceledException ex)
                {
                    // just interrupt processing
                    //ProcessingCancel?.Invoke(this, null);
                }
            });
            CancellationInvoker.Dispose();

            var logStream = (logFile != null ? new StreamWriter(logFile) : null);
            var logEntries = parallelProcessor.WriteLog(logStream);
            logStream?.WriteLine($"Main GUI Thread: {guiThread}\tMain Task Thread: {processingTaskThread}");
            logStream?.Flush();
            logFile.Dispose();

            var deltaTime = DateTime.Now - beginTime;
            ProcessingEnd?.Invoke(this, new ProcessingEndEventArgs { DeltaTime = deltaTime, RequestedFilesCount = filesToProcess.Length, ProcessedFilesCount = logEntries });
            
        }

        private async Task<FileStream> OpenLogStream(string logDirectoryPath)
        {
            if (cbDisableLog.Checked || logDirectoryPath == null || logDirectoryPath == "") return null;
            DirectoryInfo logDirectory = null;
            try
            {
                logDirectory = Directory.CreateDirectory(txtLogDest.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Cannot create a directory for log destination: {logDirectoryPath}. No log will be produced.\nMore: {ex.Message}",
                    "Log folder creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            FileStream resultLogStream = null;
            var logFileName = "img-log_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".txt";
            var logFilePath = Path.Combine(logDirectory?.FullName, logFileName);

            try
            {
                resultLogStream = File.Create(logFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Cannot create a log file: {logFilePath}. No log will be produced.\nMore: {ex.Message}",
                    "Log file creation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return resultLogStream;
        }

       
        private void OnCancelProcessing(object sender, EventArgs e)
        {
            CancellationInvoker.Cancel();
           
        }

        private void OnSelectLogDestination(object sender, EventArgs e)
        {
            var dialogResult = logDestinationFolderDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                txtLogDest.Text = logDestinationFolderDialog.SelectedPath;
            }
        }

        private void OnAddFileToList(object sender, EventArgs e)
        {
            AddingFileToListBegin?.Invoke(this, null);
            var dialogResult = imagesOpenDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                for(int i = 0; i < imagesOpenDialog.FileNames.Length; ++i)
                {
                    var fileName = imagesOpenDialog.FileNames[i];
                    if (imageList.Images.ContainsKey(fileName))
                    {
                        continue;
                    }
                    imageList.Images.Add(fileName, Image.FromFile(fileName));
                    this.listViewImages.Items.Add(fileName, imageList.Images.Count - 1);
                    
                }
                listViewImages.LargeImageList = imageList;
            }
            AddingFileToListEnd?.Invoke(this, null);
        }

        private void OnClearFilesList(object sender, EventArgs e)
        {
            ClearingFilesListBegin?.Invoke(this, null);
            listViewImages.Items.Clear();
            imageList.Images.Clear();
            ClearingFilesListEnd?.Invoke(this, null);
        }

        private void OnDisableLoggingCheckedChanged(object sender, EventArgs e)
        {
            txtLogDest.Enabled = !cbDisableLog.Checked;
            btnLogDest.Enabled = !cbDisableLog.Checked;
        }
    }
}
