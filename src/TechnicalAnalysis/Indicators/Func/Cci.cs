using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CciResult Cci(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Cci(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new CciResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static CciResult Cci(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => Cci(startIdx, endIdx, high, low, close, 14);

        public static CciResult Cci(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
            => Cci(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

        public static CciResult Cci(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => Cci(startIdx, endIdx, high, low, close, 14);
    }

    public record CciResult : IndicatorBase
    {
        public CciResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
