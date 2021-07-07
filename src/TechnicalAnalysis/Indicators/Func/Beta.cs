using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static BetaResult Beta(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Beta(
                startIdx,
                endIdx,
                real0,
                real1,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new BetaResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static BetaResult Beta(int startIdx, int endIdx, double[] real0, double[] real1)
            => Beta(startIdx, endIdx, real0, real1, 5);

        public static BetaResult Beta(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod)
            => Beta(startIdx, endIdx, real0.ToDouble(), real1.ToDouble(), timePeriod);
        
        public static BetaResult Beta(int startIdx, int endIdx, float[] real0, float[] real1)
            => Beta(startIdx, endIdx, real0, real1, 5);
    }

    public record BetaResult : IndicatorBase
    {
        public BetaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
