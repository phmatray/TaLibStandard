using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtPhasorResult HtPhasor(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outInPhase = new double[endIdx - startIdx + 1];
            double[] outQuadrature = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtPhasor(
                startIdx,
                endIdx,
                real,
                ref outBegIdx,
                ref outNBElement,
                ref outInPhase,
                ref outQuadrature);
            
            return new HtPhasorResult(retCode, outBegIdx, outNBElement, outInPhase, outQuadrature);
        }

        public static HtPhasorResult HtPhasor(int startIdx, int endIdx, float[] real)
            => HtPhasor(startIdx, endIdx, real.ToDouble());
    }

    public record HtPhasorResult : IndicatorBase
    {
        public HtPhasorResult(RetCode retCode, int begIdx, int nbElement, double[] inPhase, double[] quadrature)
            : base(retCode, begIdx, nbElement)
        {
            InPhase = inPhase;
            Quadrature = quadrature;
        }

        public double[] InPhase { get; }

        public double[] Quadrature { get; }
    }
}
