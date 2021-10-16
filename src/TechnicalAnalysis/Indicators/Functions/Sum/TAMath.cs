using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static SumResult Sum(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sum(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SumResult Sum(int startIdx, int endIdx, double[] real)
            => Sum(startIdx, endIdx, real, 30);

        public static SumResult Sum(int startIdx, int endIdx, float[] real, int timePeriod)
            => Sum(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static SumResult Sum(int startIdx, int endIdx, float[] real)
            => Sum(startIdx, endIdx, real, 30);
    }
}
