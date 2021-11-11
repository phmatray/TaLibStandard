using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static RocR100Result RocR100(int startIdx, int endIdx, double[] real, int timePeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outReal = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.RocR100(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
        return new(retCode, outBegIdx, outNBElement, outReal);
    }

    public static RocR100Result RocR100(int startIdx, int endIdx, double[] real)
        => RocR100(startIdx, endIdx, real, 10);

    public static RocR100Result RocR100(int startIdx, int endIdx, float[] real, int timePeriod)
        => RocR100(startIdx, endIdx, real.ToDouble(), timePeriod);
        
    public static RocR100Result RocR100(int startIdx, int endIdx, float[] real)
        => RocR100(startIdx, endIdx, real, 10);
}