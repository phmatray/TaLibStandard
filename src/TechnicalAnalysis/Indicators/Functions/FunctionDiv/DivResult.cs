using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionDiv;

public record DivResult : IndicatorBase
{
    public DivResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}