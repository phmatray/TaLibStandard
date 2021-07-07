using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static ApoResult Apo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, MAType maType)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Apo(
                startIdx,
                endIdx,
                real,
                fastPeriod,
                slowPeriod,
                maType,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new ApoResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static ApoResult Apo(int startIdx, int endIdx, double[] real)
            => Apo(startIdx, endIdx, real, 12, 26, MAType.Sma);

        public static ApoResult Apo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, MAType maType)
            => Apo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);

        public static ApoResult Apo(int startIdx, int endIdx, float[] real)
            => Apo(startIdx, endIdx, real, 12, 26, MAType.Sma);
    }

    public record ApoResult : IndicatorBase
    {
        public ApoResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
