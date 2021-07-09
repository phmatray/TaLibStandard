using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static WmaResult Wma(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Wma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            return new WmaResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static WmaResult Wma(int startIdx, int endIdx, double[] real)
            => Wma(startIdx, endIdx, real, 30);

        public static WmaResult Wma(int startIdx, int endIdx, float[] real, int timePeriod)
            => Wma(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static WmaResult Wma(int startIdx, int endIdx, float[] real)
            => Wma(startIdx, endIdx, real, 30);
    }
}
