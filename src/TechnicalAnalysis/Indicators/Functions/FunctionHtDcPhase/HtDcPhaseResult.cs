using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionHtDcPhase;

public record HtDcPhaseResult : IndicatorBase
{
    public HtDcPhaseResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}