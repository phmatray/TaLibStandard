using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionRoc;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static RocResult Roc(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Roc(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new RocResult(retCode, outBegIdx, outNBElement, outReal);
    }

    public static RocResult Roc(int startIdx, int endIdx, double[] real)
        => Roc(startIdx, endIdx, real, 10);

    public static RocResult Roc(int startIdx, int endIdx, float[] real, int timePeriod)
        => Roc(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static RocResult Roc(int startIdx, int endIdx, float[] real)
        => Roc(startIdx, endIdx, real, 10);
}