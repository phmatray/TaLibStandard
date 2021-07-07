using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CosResult Cos(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Cos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new CosResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static CosResult Cos(int startIdx, int endIdx, float[] real)
            => Cos(startIdx, endIdx, real.ToDouble());
    }

    public record CosResult : IndicatorBase
    {
        public CosResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
