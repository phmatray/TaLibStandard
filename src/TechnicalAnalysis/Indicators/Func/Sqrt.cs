using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static SqrtResult Sqrt(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sqrt(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new SqrtResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SqrtResult Sqrt(int startIdx, int endIdx, float[] real)
            => Sqrt(startIdx, endIdx, real.ToDouble());
    }

    public record SqrtResult : IndicatorBase
    {
        public SqrtResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
