using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MfiResult Mfi(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            double[] volume,
            int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Mfi(
                startIdx,
                endIdx,
                high,
                low,
                close,
                volume,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new MfiResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MfiResult Mfi(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume)
            => Mfi(startIdx, endIdx, high, low, close, volume, 14);

        public static MfiResult Mfi(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            float[] volume,
            int timePeriod)
            => Mfi(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), volume.ToDouble(), timePeriod);
        
        public static MfiResult Mfi(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume)
            => Mfi(startIdx, endIdx, high, low, close, volume, 14);
    }

    public record MfiResult : IndicatorBase
    {
        public MfiResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
