using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtDcPeriodResult HtDcPeriod(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtDcPeriod(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new HtDcPeriodResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static HtDcPeriodResult HtDcPeriod(int startIdx, int endIdx, float[] real)
            => HtDcPeriod(startIdx, endIdx, real.ToDouble());
    }

    public record HtDcPeriodResult : IndicatorBase
    {
        public HtDcPeriodResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
