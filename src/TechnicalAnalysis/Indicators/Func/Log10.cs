using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Log10Result Log10(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Log10(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Log10Result(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Log10Result Log10(int startIdx, int endIdx, float[] real)
            => Log10(startIdx, endIdx, real.ToDouble());
    }

    public record Log10Result : IndicatorBase
    {
        public Log10Result(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
