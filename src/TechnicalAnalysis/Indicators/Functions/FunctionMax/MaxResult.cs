using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMax;

public record MaxResult : IndicatorBase
{
    public MaxResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}