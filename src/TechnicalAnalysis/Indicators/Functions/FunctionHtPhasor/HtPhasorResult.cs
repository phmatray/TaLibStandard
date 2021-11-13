using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionHtPhasor;

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