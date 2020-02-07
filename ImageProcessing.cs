﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab01
{
    
    public class ImageProcessing
    {
        public class ProcessingMetaInfo
        {
            public DateTime ProcessingBegin { get; set; }
            public DateTime ProcessingEnd { get; set; }
            public int ThreadId { get; set; }
            public int? TaskId { get; set; }
            public bool Success { get; set; }

        }
        public static Bitmap ProcessImage(Bitmap image, int tileSizePx)
        {
            int cols = image.Width / tileSizePx;
            int remWidth = image.Width % tileSizePx;
            int rows = image.Height / tileSizePx;
            int remHeight = image.Height % tileSizePx;
            var rowAverages = new ColorAccumulator[cols + (remWidth == 0 ? 0 : 1)];
            var resultImage = new Bitmap(image.Width, image.Height);
            int pixelCol = 0, pixelRow = 0;

            for (int row = 0; row <= rows; ++row)
            {
                int rowTileLimit = (row == rows) ? remHeight : tileSizePx;
                if (rowTileLimit == 0) continue;

                // Sum up colors for current row of tiles
                for (int tileRowPx = 0; tileRowPx < rowTileLimit; ++tileRowPx)
                {
                    pixelCol = 0;
                    for (int col = 0; col <= cols; ++col)
                    {
                        int colTileLimit = (col == cols) ? remWidth : tileSizePx;
                        for (int tileColPx = 0; tileColPx < colTileLimit; ++tileColPx)
                        {
                            rowAverages[col].Add(image.GetPixel(pixelCol + tileColPx, pixelRow + tileRowPx));
                        }
                        pixelCol += tileSizePx;
                    }
                }

                // Average color on current row of tiles
                for (int col = 0; col < rowAverages.Length; ++col)
                {
                    rowAverages[col].ConvertToAverageColor();
                }

                // Assign average color on current row of tiles
                for (int tileRowPx = 0; tileRowPx < rowTileLimit; ++tileRowPx)
                {
                    pixelCol = 0;
                    for (int col = 0; col <= cols; ++col)
                    {
                        int colTileLimit = (col == cols) ? remWidth : tileSizePx;
                        for (int tileColPx = 0; tileColPx < colTileLimit; ++tileColPx)
                        {
                            resultImage.SetPixel(pixelCol + tileColPx, pixelRow + tileRowPx, rowAverages[col].CurrentColor);
                        }
                        pixelCol += tileSizePx;
                    }
                }

                // Clear average info for current row of tiles
                for (int col = 0; col < rowAverages.Length; ++col)
                {
                    rowAverages[col] = new ColorAccumulator();
                }
                pixelRow += tileSizePx;
            }
            return resultImage;
        }

        public static ProcessingMetaInfo ProcessImageFile(string srcImagePath, string dstImagePathNoExtention, int tileSizePx)
        {
            var metaInfo = new ProcessingMetaInfo();
            metaInfo.ProcessingBegin = DateTime.Now;
            metaInfo.ThreadId = Thread.CurrentThread.ManagedThreadId;
            metaInfo.TaskId = Task.CurrentId;
            metaInfo.Success = true;
            Bitmap srcImage = null;

            try
            {
                srcImage = new Bitmap(srcImagePath);
            }
            catch
            {
                metaInfo.Success = false;
            }

            var resultImage = ProcessImage(srcImage, tileSizePx);
            srcImage.Dispose();
            var imageFileExtention = Path.GetExtension(srcImagePath);
            try
            {
                ImageFormat imageFormat = null;
                switch (imageFileExtention) {
                    case "png": imageFormat = ImageFormat.Png; break;
                    case "bmp": imageFormat = ImageFormat.Bmp; break;
                    case "jpg": case "jpeg": imageFormat = ImageFormat.Jpeg; break;
                    default: imageFormat = ImageFormat.Png; break;
                }
                resultImage.Save(dstImagePathNoExtention + imageFileExtention, imageFormat);
            }
            catch
            {
                metaInfo.Success = false;
            }

            resultImage.Dispose();
            metaInfo.ProcessingEnd = DateTime.Now;
            return metaInfo;
        }

        protected struct ColorAccumulator
        {
            int r, g, b, a;
            int counter;
            public Color CurrentColor => Color.FromArgb(a, r, g, b);
            public Color AverageColor => Color.FromArgb(a / counter, r / counter, g / counter, b / counter);
            public void Add(Color color)
            {
                r += color.R;
                g += color.G;
                b += color.B;
                a += color.A;
                counter++;
            }


            public void ConvertToAverageColor()
            {
                a /= counter;
                r /= counter;
                g /= counter;
                b /= counter;
            }
        }

    }
}
