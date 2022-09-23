using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class Treshold
{
    static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(0.0, new double[,] { { 123 } }, new double[,] { { 0 } });
        yield return new TestCaseData(1.0, new double[,] { { 123 } }, new double[,] { { 1 } });
        yield return new TestCaseData(0.5, new double[,] { { 1, 2, 2, 3 } }, new double[,] { { 0, 1, 1, 1 } });
    }

    [TestCaseSource(nameof(TestCases))]

    public void Test(double whitePixelsFraction, double[,] original, double[,] expected)
    {
        var result = ThresholdFilter.Threshold(original, whitePixelsFraction);
        Assert.AreEqual(result, expected);
    }
}
