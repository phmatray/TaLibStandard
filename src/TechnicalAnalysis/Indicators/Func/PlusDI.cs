using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static PlusDIResult PlusDI(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.PlusDI(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new PlusDIResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static PlusDIResult PlusDI(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => PlusDI(startIdx, endIdx, high, low, close, 14);

        public static PlusDIResult PlusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
            => PlusDI(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);
        
        public static PlusDIResult PlusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => PlusDI(startIdx, endIdx, high, low, close, 14);
    }

    public record PlusDIResult : IndicatorBase
    {
        public PlusDIResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
