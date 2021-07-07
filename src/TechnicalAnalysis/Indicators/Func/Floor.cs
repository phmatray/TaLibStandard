using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static FloorResult Floor(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Floor(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            return new FloorResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static FloorResult Floor(int startIdx, int endIdx, float[] real)
            => Floor(startIdx, endIdx, real.ToDouble());
    }

    public record FloorResult : IndicatorBase
    {
        public FloorResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
