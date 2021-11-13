using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionVariance;

public record VarianceResult : IndicatorBase
{
    public VarianceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}