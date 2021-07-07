using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static SinResult Sin(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sin(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new SinResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SinResult Sin(int startIdx, int endIdx, float[] real)
            => Sin(startIdx, endIdx, real.ToDouble());
    }

    public record SinResult : IndicatorBase
    {
        public SinResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
