using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static TypPriceResult TypPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.TypPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, ref outReal);
            return new(retCode, outBegIdx, outNBElement, outReal);
        }

        public static TypPriceResult TypPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => TypPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
