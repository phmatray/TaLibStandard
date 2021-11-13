using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionSar;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static SarResult Sar(
        int startIdx,
        int endIdx,
        double[] high,
        double[] low,
        double acceleration,
        double maximum)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Sar(
            startIdx,
            endIdx,
            high,
            low,
            acceleration,
            maximum,
            ref outBegIdx,
            ref outNBElement,
            ref outReal);
            
        return new SarResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static SarResult Sar(int startIdx, int endIdx, double[] high, double[] low)
        => Sar(startIdx, endIdx, high, low, 0.02, 0.2);

    public static SarResult Sar(int startIdx, int endIdx, float[] high, float[] low, double acceleration, double maximum)
        => Sar(startIdx, endIdx, high.ToDouble(), low.ToDouble(), acceleration, maximum);
        
    public static SarResult Sar(int startIdx, int endIdx, float[] high, float[] low)
        => Sar(startIdx, endIdx, high, low, 0.02, 0.2);
}