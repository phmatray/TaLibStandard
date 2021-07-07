using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static ExpResult Exp(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Exp(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new ExpResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static ExpResult Exp(int startIdx, int endIdx, float[] real)
            => Exp(startIdx, endIdx, real.ToDouble());
    }

    public record ExpResult : IndicatorBase
    {
        public ExpResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
