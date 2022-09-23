using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class GrayScale
{
    public static double[,] Gray(Pixel[,] original)
    {
        var length = original.GetLength(0);
        var width = original.GetLength(1);
        var grayPixels = new double[length, width];

        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < width; y++)
                grayPixels[x, y] = (original[x, y].R * 0.299 + original[x, y].G * 0.587 + original[x, y].B * 0.114) / 255;
        }
        return grayPixels;
    }
}
