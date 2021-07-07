using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static DivResult Div(int startIdx, int endIdx, double[] real0, double[] real1)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Div(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new DivResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static DivResult Div(int startIdx, int endIdx, float[] real0, float[] real1)
            => Div(startIdx, endIdx, real0.ToDouble(), real1.ToDouble());
    }

    public record DivResult : IndicatorBase
    {
        public DivResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
