using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtTrendlineResult HtTrendline(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtTrendline(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new HtTrendlineResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static HtTrendlineResult HtTrendline(int startIdx, int endIdx, float[] real)
            => HtTrendline(startIdx, endIdx, real.ToDouble());
    }

    public record HtTrendlineResult : IndicatorBase
    {
        public HtTrendlineResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
