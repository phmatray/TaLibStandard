using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static AvgPriceResult AvgPrice(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.AvgPrice(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new(retCode, outBegIdx, outNBElement, outReal);
        }

        public static AvgPriceResult AvgPrice(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => AvgPrice(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
