using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionCorrel;

public record CorrelResult : IndicatorBase
{
    public CorrelResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}