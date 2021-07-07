using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static AdResult Ad(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Ad(
                startIdx,
                endIdx,
                high,
                low,
                close,
                volume,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);

            return new AdResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static AdResult Ad(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume)
            => Ad(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), volume.ToDouble());
    }

    public record AdResult : IndicatorBase
    {
        public AdResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
