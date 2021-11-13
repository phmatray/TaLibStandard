using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionKama;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static KamaResult Kama(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = 0;
        int outNBElement = 0;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.Kama(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new KamaResult(retCode, outBegIdx, outNBElement, outReal);
    }
        
    public static KamaResult Kama(int startIdx, int endIdx, double[] real)
        => Kama(startIdx, endIdx, real, 30);

    public static KamaResult Kama(int startIdx, int endIdx, float[] real, int timePeriod)
        => Kama(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static KamaResult Kama(int startIdx, int endIdx, float[] real)
        => Kama(startIdx, endIdx, real, 30);
}