using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MinusDMResult MinusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinusDM(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new MinusDMResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MinusDMResult MinusDM(int startIdx, int endIdx, double[] high, double[] low)
            => MinusDM(startIdx, endIdx, high, low, 14);

        public static MinusDMResult MinusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
            => MinusDM(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

        public static MinusDMResult MinusDM(int startIdx, int endIdx, float[] high, float[] low)
            => MinusDM(startIdx, endIdx, high, low, 14);
    }

    public record MinusDMResult : IndicatorBase
    {
        public MinusDMResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
