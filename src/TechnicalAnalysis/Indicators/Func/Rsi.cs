using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static RsiResult Rsi(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Rsi(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            return new RsiResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static RsiResult Rsi(int startIdx, int endIdx, double[] real)
            => Rsi(startIdx, endIdx, real, 14);

        public static RsiResult Rsi(int startIdx, int endIdx, float[] real, int timePeriod)
            => Rsi(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static RsiResult Rsi(int startIdx, int endIdx, float[] real)
            => Rsi(startIdx, endIdx, real, 14);
    }

    public record RsiResult : IndicatorBase
    {
        public RsiResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
