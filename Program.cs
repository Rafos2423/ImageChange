using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageChanger
{
    internal static class Program
    {
        public static Bitmap ConvertToBitmap(Pixel[,] pixels)
        {
            var width = pixels.GetLength(0);
            var height = pixels.GetLength(1);

            var bmp = new Bitmap(width, height);
            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                    bmp.SetPixel(x, y, Color.FromArgb(pixels[x,y].R, pixels[x, y].G, pixels[x, y].B));

            return bmp;
        }

        public static Bitmap ConvertToBitmap(double[,] array)
        {
            var width = array.GetLength(0);
            var height = array.GetLength(1);

            var bmp = new Bitmap(width, height);

            for (var x = 0; x < width; x++)
                for (var y = 0; y < height; y++)
                {
                    var gray = (int)(255 * array[x, y]);
                    if (gray < 0) gray = 0;
                    else if (gray > 255) gray = 255;
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }

            return bmp;
        }

        public static Pixel[,] ConvertToPixels(Bitmap bmp)
        {
            var pixels = new Pixel[bmp.Width, bmp.Height];
            for (int x = 0; x < bmp.Width; x++)
                for (int y = 0; y < bmp.Height; y++)
                    pixels[x, y] = new Pixel(bmp.GetPixel(x, y));

            return pixels;
        }

        public static Bitmap RunProcessing(Bitmap bmp)
        {
            var pixels = Program.ConvertToPixels(bmp);
            double[,] greyPixels = GrayScale.Gray(pixels);
            double[,] clearPixels = MedianFilter.Median(greyPixels);
            var sobelFilter = new double[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            double[,] countourPixels = SobelFilter.Sobel(clearPixels, sobelFilter);
            double[,] whiteBlackPixels = ThresholdFilter.Threshold(countourPixels, 0.1);

            return ConvertToBitmap(whiteBlackPixels);
        }

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }
    }
}
