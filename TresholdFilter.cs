using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ThresholdFilter
{
    public static double[,] Threshold(double[,] original, double whitePixelsFraction)
    {
        var T = FindT(original, whitePixelsFraction);

        for (int i = 0; i < original.GetLength(0); i++)
        {
            for (int j = 0; j < original.GetLength(1); j++)
                original[i, j] = (original[i, j] >= T) ? 1 : 0;
        }

        return original;
    }

    public static double FindT(double[,] original, double whitePixelsFraction)
    {
        var N = original.GetLength(0) * original.GetLength(1);
        var countWhite = (int)(N * whitePixelsFraction);

        var pixels = original.Cast<double>().ToList();
        pixels.Sort();

        return (countWhite == 0) ? pixels.Max() + 1 : pixels[pixels.Count - countWhite];
    }
}