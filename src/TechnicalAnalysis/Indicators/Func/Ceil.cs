using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CeilResult Ceil(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Ceil(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new CeilResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static CeilResult Ceil(int startIdx, int endIdx, float[] real)
            => Ceil(startIdx, endIdx, real.ToDouble());
    }

    public record CeilResult : IndicatorBase
    {
        public CeilResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
