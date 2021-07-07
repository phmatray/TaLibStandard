using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static LnResult Ln(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Ln(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new LnResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static LnResult Ln(int startIdx, int endIdx, float[] real)
            => Ln(startIdx, endIdx, real.ToDouble());
    }

    public record LnResult : IndicatorBase
    {
        public LnResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
