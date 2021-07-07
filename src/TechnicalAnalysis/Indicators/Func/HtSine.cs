using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtSineResult HtSine(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outSine = new double[endIdx - startIdx + 1];
            double[] outLeadSine = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtSine(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outSine, ref outLeadSine);
            
            return new HtSineResult(retCode, outBegIdx, outNBElement, outSine, outLeadSine);
        }

        public static HtSineResult HtSine(int startIdx, int endIdx, float[] real)
            => HtSine(startIdx, endIdx, real.ToDouble());
    }

    public record HtSineResult : IndicatorBase
    {
        public HtSineResult(RetCode retCode, int begIdx, int nbElement, double[] sine, double[] leadSine)
            : base(retCode, begIdx, nbElement)
        {
            Sine = sine;
            LeadSine = leadSine;
        }

        public double[] LeadSine { get; }

        public double[] Sine { get; }
    }
}
