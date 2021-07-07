using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MaxResult Max(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Max(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new MaxResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MaxResult Max(int startIdx, int endIdx, double[] real)
            => Max(startIdx, endIdx, real, 30);

        public static MaxResult Max(int startIdx, int endIdx, float[] real, int timePeriod)
            => Max(startIdx, endIdx, real.ToDouble(), timePeriod);

        public static MaxResult Max(int startIdx, int endIdx, float[] real)
            => Max(startIdx, endIdx, real, 30);
    }

    public record MaxResult : IndicatorBase
    {
        public MaxResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
