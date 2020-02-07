namespace Lab01
{
    partial class ImageProcessorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblLogDest;
            System.Windows.Forms.Label lblFiles;
            System.Windows.Forms.Label lblNewPixelSize;
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtLogDest = new System.Windows.Forms.TextBox();
            this.btnLogDest = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.listViewImages = new System.Windows.Forms.ListView();
            this.btnAddFileToList = new System.Windows.Forms.Button();
            this.btnClearFilesList = new System.Windows.Forms.Button();
            this.imagesOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.logDestinationFolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.preprocessingConfigPanel = new System.Windows.Forms.Panel();
            this.cbDisableLog = new System.Windows.Forms.CheckBox();
            this.cbParallel = new System.Windows.Forms.CheckBox();
            this.numNewPixelSize = new System.Windows.Forms.NumericUpDown();
            lblLogDest = new System.Windows.Forms.Label();
            lblFiles = new System.Windows.Forms.Label();
            lblNewPixelSize = new System.Windows.Forms.Label();
            this.preprocessingConfigPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNewPixelSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLogDest
            // 
            lblLogDest.AutoSize = true;
            lblLogDest.Location = new System.Drawing.Point(1, 10);
            lblLogDest.Name = "lblLogDest";
            lblLogDest.Size = new System.Drawing.Size(100, 13);
            lblLogDest.TabIndex = 3;
            lblLogDest.Text = "Log File Destination";
            // 
            // lblFiles
            // 
            lblFiles.AutoSize = true;
            lblFiles.Location = new System.Drawing.Point(1, 72);
            lblFiles.Name = "lblFiles";
            lblFiles.Size = new System.Drawing.Size(80, 13);
            lblFiles.TabIndex = 6;
            lblFiles.Text = "Files to process";
            // 
            // lblNewPixelSize
            // 
            lblNewPixelSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            lblNewPixelSize.AutoSize = true;
            lblNewPixelSize.Location = new System.Drawing.Point(249, 75);
            lblNewPixelSize.Name = "lblNewPixelSize";
            lblNewPixelSize.Size = new System.Drawing.Size(64, 13);
            lblNewPixelSize.TabIndex = 9;
            lblNewPixelSize.Text = "New px size";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(221, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.OnStartProcessing);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(311, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.OnCancelProcessing);
            // 
            // txtLogDest
            // 
            this.txtLogDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogDest.Location = new System.Drawing.Point(3, 26);
            this.txtLogDest.Name = "txtLogDest";
            this.txtLogDest.Size = new System.Drawing.Size(340, 20);
            this.txtLogDest.TabIndex = 2;
            // 
            // btnLogDest
            // 
            this.btnLogDest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogDest.Location = new System.Drawing.Point(346, 24);
            this.btnLogDest.Name = "btnLogDest";
            this.btnLogDest.Size = new System.Drawing.Size(28, 22);
            this.btnLogDest.TabIndex = 4;
            this.btnLogDest.Text = ">";
            this.btnLogDest.UseVisualStyleBackColor = true;
            this.btnLogDest.Click += new System.EventHandler(this.OnSelectLogDestination);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.imageList.ImageSize = new System.Drawing.Size(90, 85);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // listViewImages
            // 
            this.listViewImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewImages.HideSelection = false;
            this.listViewImages.Location = new System.Drawing.Point(0, 96);
            this.listViewImages.MultiSelect = false;
            this.listViewImages.Name = "listViewImages";
            this.listViewImages.Size = new System.Drawing.Size(377, 237);
            this.listViewImages.TabIndex = 5;
            this.listViewImages.UseCompatibleStateImageBehavior = false;
            // 
            // btnAddFileToList
            // 
            this.btnAddFileToList.Location = new System.Drawing.Point(86, 67);
            this.btnAddFileToList.Name = "btnAddFileToList";
            this.btnAddFileToList.Size = new System.Drawing.Size(62, 23);
            this.btnAddFileToList.TabIndex = 0;
            this.btnAddFileToList.Text = "ADD";
            this.btnAddFileToList.UseVisualStyleBackColor = true;
            this.btnAddFileToList.Click += new System.EventHandler(this.OnAddFileToList);
            // 
            // btnClearFilesList
            // 
            this.btnClearFilesList.Location = new System.Drawing.Point(154, 67);
            this.btnClearFilesList.Name = "btnClearFilesList";
            this.btnClearFilesList.Size = new System.Drawing.Size(62, 23);
            this.btnClearFilesList.TabIndex = 8;
            this.btnClearFilesList.Text = "CLEAR";
            this.btnClearFilesList.UseVisualStyleBackColor = true;
            this.btnClearFilesList.Click += new System.EventHandler(this.OnClearFilesList);
            // 
            // imagesOpenDialog
            // 
            this.imagesOpenDialog.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp";
            this.imagesOpenDialog.InitialDirectory = "C:\\Users\\";
            this.imagesOpenDialog.Multiselect = true;
            // 
            // logDestinationFolderDialog
            // 
            this.logDestinationFolderDialog.SelectedPath = "C:\\ProgramData";
            // 
            // preprocessingConfigPanel
            // 
            this.preprocessingConfigPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.preprocessingConfigPanel.Controls.Add(this.cbDisableLog);
            this.preprocessingConfigPanel.Controls.Add(lblNewPixelSize);
            this.preprocessingConfigPanel.Controls.Add(this.cbParallel);
            this.preprocessingConfigPanel.Controls.Add(this.numNewPixelSize);
            this.preprocessingConfigPanel.Controls.Add(this.txtLogDest);
            this.preprocessingConfigPanel.Controls.Add(this.btnClearFilesList);
            this.preprocessingConfigPanel.Controls.Add(lblLogDest);
            this.preprocessingConfigPanel.Controls.Add(this.btnAddFileToList);
            this.preprocessingConfigPanel.Controls.Add(this.btnLogDest);
            this.preprocessingConfigPanel.Controls.Add(lblFiles);
            this.preprocessingConfigPanel.Controls.Add(this.listViewImages);
            this.preprocessingConfigPanel.Location = new System.Drawing.Point(12, 41);
            this.preprocessingConfigPanel.Name = "preprocessingConfigPanel";
            this.preprocessingConfigPanel.Size = new System.Drawing.Size(377, 333);
            this.preprocessingConfigPanel.TabIndex = 9;
            // 
            // cbDisableLog
            // 
            this.cbDisableLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDisableLog.AutoSize = true;
            this.cbDisableLog.Location = new System.Drawing.Point(252, 6);
            this.cbDisableLog.Name = "cbDisableLog";
            this.cbDisableLog.Size = new System.Drawing.Size(102, 17);
            this.cbDisableLog.TabIndex = 10;
            this.cbDisableLog.Text = "Disable Logging";
            this.cbDisableLog.UseVisualStyleBackColor = true;
            this.cbDisableLog.CheckedChanged += new System.EventHandler(this.OnDisableLoggingCheckedChanged);
            // 
            // cbParallel
            // 
            this.cbParallel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbParallel.AutoSize = true;
            this.cbParallel.Checked = true;
            this.cbParallel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbParallel.Location = new System.Drawing.Point(252, 52);
            this.cbParallel.Name = "cbParallel";
            this.cbParallel.Size = new System.Drawing.Size(111, 17);
            this.cbParallel.TabIndex = 9;
            this.cbParallel.Text = "Process in parallel";
            this.cbParallel.UseVisualStyleBackColor = true;
            // 
            // numNewPixelSize
            // 
            this.numNewPixelSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numNewPixelSize.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numNewPixelSize.Location = new System.Drawing.Point(313, 70);
            this.numNewPixelSize.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numNewPixelSize.Name = "numNewPixelSize";
            this.numNewPixelSize.Size = new System.Drawing.Size(61, 20);
            this.numNewPixelSize.TabIndex = 9;
            this.numNewPixelSize.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ImageProcessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 386);
            this.Controls.Add(this.preprocessingConfigPanel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart);
            this.MinimumSize = new System.Drawing.Size(360, 360);
            this.Name = "ImageProcessorForm";
            this.Text = "Image Pixelator";
            this.preprocessingConfigPanel.ResumeLayout(false);
            this.preprocessingConfigPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numNewPixelSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtLogDest;
        private System.Windows.Forms.Button btnLogDest;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView listViewImages;
        private System.Windows.Forms.Button btnAddFileToList;
        private System.Windows.Forms.Button btnClearFilesList;
        private System.Windows.Forms.OpenFileDialog imagesOpenDialog;
        private System.Windows.Forms.FolderBrowserDialog logDestinationFolderDialog;
        private System.Windows.Forms.Panel preprocessingConfigPanel;
        private System.Windows.Forms.NumericUpDown numNewPixelSize;
        private System.Windows.Forms.CheckBox cbParallel;
        private System.Windows.Forms.CheckBox cbDisableLog;
    }
}

