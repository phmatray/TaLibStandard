using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static WclPriceResult WclPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.WclPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new WclPriceResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static WclPriceResult WclPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => WclPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public record WclPriceResult : IndicatorBase
    {
        public WclPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
