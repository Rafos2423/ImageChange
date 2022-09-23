using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SobelFilter
{
    public static double[,] Sobel(double[,] g, double[,] sx)
    {
        var width = g.GetLength(0);
        var height = g.GetLength(1);
        var result = new double[width, height];
        var offset = sx.GetLength(0) / 2;

        for (int x = offset; x < width - offset; x++)
        {
            for (int y = offset; y < height - offset; y++)
            {
                var gx = 0.0;
                var gy = 0.0;

                for (int i = x - offset; i <= x + offset; i++)
                {
                    for (int j = y - offset; j <= y + offset; j++)
                    {
                        gx += g[i, j] * sx[i - x + offset, j - y + offset];
                        gy += g[i, j] * sx[j - y + offset, i - x + offset];
                    }
                }

                result[x, y] = Math.Sqrt(gx * gx + gy * gy);
            }
        }
        return result;
    }
}