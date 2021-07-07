using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static AroonOscResult AroonOsc(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.AroonOsc(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new AroonOscResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static AroonOscResult AroonOsc(int startIdx, int endIdx, double[] high, double[] low)
            => AroonOsc(startIdx, endIdx, high, low, 14);

        public static AroonOscResult AroonOsc(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
            => AroonOsc(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

        public static AroonOscResult AroonOsc(int startIdx, int endIdx, float[] high, float[] low)
            => AroonOsc(startIdx, endIdx, high, low, 14);
    }

    public record AroonOscResult : IndicatorBase
    {
        public AroonOscResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
