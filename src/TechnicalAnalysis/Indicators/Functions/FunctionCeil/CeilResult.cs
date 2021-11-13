using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionCeil;

public record CeilResult : IndicatorBase
{
    public CeilResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}