using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static HtDcPeriodResult HtDcPeriod(int startIdx, int endIdx, double[] real)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.HtDcPeriod(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new HtDcPeriodResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static HtDcPeriodResult HtDcPeriod(int startIdx, int endIdx, float[] real)
        => HtDcPeriod(startIdx, endIdx, real.ToDouble());
}