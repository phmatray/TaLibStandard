using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CoshResult Cosh(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Cosh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new CoshResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static CoshResult Cosh(int startIdx, int endIdx, float[] real)
            => Cosh(startIdx, endIdx, real.ToDouble());
    }

    public record CoshResult : IndicatorBase
    {
        public CoshResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
