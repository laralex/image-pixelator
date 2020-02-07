using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Lab01.ImageProcessing;

namespace Lab01
{
    public class ParallelProcessing
    {
        private const int STATIC_BALANCING_WINDOW_SIZE = 6;
        public List<Tuple<ProcessingMetaInfo, string>> MetaInfoBuffer { get; private set; }
        public ParallelProcessing()
        {
            MetaInfoBuffer = new List<Tuple<ProcessingMetaInfo, string>>();
        }

        public ProcessingMetaInfo ProcessImage(string imagePath, int tileSizePx, CancellationToken cancellationToken)
        {
            var imageFileName = Path.GetFileNameWithoutExtension(imagePath);
            var imageDir = Path.GetDirectoryName(imagePath);
            var dstImagePath = Path.Combine(imageDir, imageFileName + "-processed");
            return new CancellableImageProcessing { CancellationToken = cancellationToken }
                .ProcessImageFile(imagePath, dstImagePath, tileSizePx);
        }
        public void ProcessImages(string[] images, int tileSizePx, CancellationToken cancellationToken)
        {
            foreach(var imagePath in images)
            {
                var processingResult = ProcessImage(imagePath, tileSizePx, cancellationToken);
                MetaInfoBuffer.Add(Tuple.Create(processingResult, imagePath));
            }
        }

        public void ProcessImagesInParallel(string[] images, int tileSizePx, int maxParallelism, CancellationToken cancellationToken)
        {
            ParallelOptions options = new ParallelOptions();
            options.CancellationToken = cancellationToken;
            if (maxParallelism >= 1) options.MaxDegreeOfParallelism = maxParallelism;

            // auto-balancing
            /*
            Parallel.ForEach(Partitioner.Create(images, true), options, img => {
                var processingResult = ProcessImage(img, tileSizePx, cancellationToken);
                lock (MetaInfoBuffer) { MetaInfoBuffer.Add(Tuple.Create(processingResult, img)); }
            });
            */

            // static balancing
            /*
            Parallel.ForEach(Partitioner.Create(0, images.Length), options, range => {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    var processingResult = ProcessImage(images[i], tileSizePx, cancellationToken);
                    lock (MetaInfoBuffer) { MetaInfoBuffer.Add(Tuple.Create(processingResult, images[i])); }
                }
            });
            */

            // static windowed balancing
            /*
            Parallel.ForEach(Partitioner.Create(0, images.Length, STATIC_BALANCING_WINDOW_SIZE), options, range => {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    var processingResult = ProcessImage(images[i], tileSizePx, cancellationToken);
                    lock (MetaInfoBuffer) { MetaInfoBuffer.Add(Tuple.Create(processingResult, images[i])); }
                }   
            });
            */

            // standard balancing         
            Parallel.ForEach(images, options, (img) => {
                var processingResult = ProcessImage(img, tileSizePx, cancellationToken);
                lock(MetaInfoBuffer) { MetaInfoBuffer.Add(Tuple.Create(processingResult, img)); }
            });
            
        }

        public int WriteLog(StreamWriter logWriter)
        {
            int logEntries = 0;
            foreach(var metaInfo in MetaInfoBuffer)
            {
                if (!metaInfo.Item1.Success)
                {
                    logWriter.WriteLine($"Error processing file " + metaInfo.Item2);
                    continue;
                }
                logWriter.WriteLine($"{metaInfo.Item1.ProcessingBegin.ToLongTimeString() + ':' + metaInfo.Item1.ProcessingBegin.Millisecond}\t" +
                   $"{metaInfo.Item1.ProcessingEnd.ToLongTimeString() + ':' + metaInfo.Item1.ProcessingEnd.Millisecond}\t" +
                   $"thread: {metaInfo.Item1.ThreadId}\t" +
                   $"task:{metaInfo.Item1.TaskId}\t" +
                   $"file:{metaInfo.Item2}");
                ++logEntries;
            }
            logWriter.Flush();
            MetaInfoBuffer.Clear();
            return logEntries;
        }
    }
}
