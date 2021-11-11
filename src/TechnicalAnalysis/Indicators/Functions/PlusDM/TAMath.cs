using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static PlusDMResult PlusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.PlusDM(
            startIdx,
            endIdx,
            high,
            low,
            timePeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static PlusDMResult PlusDM(int startIdx, int endIdx, double[] high, double[] low)
        => PlusDM(startIdx, endIdx, high, low, 14);

    public static PlusDMResult PlusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
        => PlusDM(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

    public static PlusDMResult PlusDM(int startIdx, int endIdx, float[] high, float[] low)
        => PlusDM(startIdx, endIdx, high, low, 14);
}