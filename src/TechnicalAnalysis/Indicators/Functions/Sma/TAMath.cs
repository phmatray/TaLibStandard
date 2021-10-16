using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static SmaResult Sma(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SmaResult Sma(int startIdx, int endIdx, double[] real)
            => Sma(startIdx, endIdx, real, 30);

        public static SmaResult Sma(int startIdx, int endIdx, float[] real, int timePeriod)
            => Sma(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static SmaResult Sma(int startIdx, int endIdx, float[] real)
            => Sma(startIdx, endIdx, real, 30);
    }
}
