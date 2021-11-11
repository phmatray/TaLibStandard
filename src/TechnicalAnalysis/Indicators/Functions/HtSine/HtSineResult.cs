using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

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