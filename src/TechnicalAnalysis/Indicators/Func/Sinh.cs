using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static SinhResult Sinh(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sinh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new SinhResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SinhResult Sinh(int startIdx, int endIdx, float[] real)
            => Sinh(startIdx, endIdx, real.ToDouble());
    }

    public record SinhResult : IndicatorBase
    {
        public SinhResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
