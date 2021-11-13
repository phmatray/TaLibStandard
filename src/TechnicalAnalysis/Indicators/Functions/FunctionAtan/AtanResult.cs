using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAtan;

public record AtanResult : IndicatorBase
{
    public AtanResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}