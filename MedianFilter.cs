using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MedianFilter
{
    public static double[,] Median(double[,] original)
    {
        var length = original.GetLength(0);
        var width = original.GetLength(1);
        var result = new double[length, width];

        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < width; y++)
            {
                result[x, y] = FindMedian(x, y, original);
            }
        }

        return result;
    }

    public static double FindMedian(int x, int y, double[,] original)
    {
        var neighbours = new List<double>();

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                if (i == -1 || j == -1 || i == original.GetLength(0) || j == original.GetLength(1))
                    continue;

                neighbours.Add(original[i, j]);
            }
        }

        neighbours.Sort();

        var count = neighbours.Count;
        return (count % 2 == 1) ? neighbours[count / 2] :
            (neighbours[count / 2] + neighbours[count / 2 - 1]) / 2;
    }
}