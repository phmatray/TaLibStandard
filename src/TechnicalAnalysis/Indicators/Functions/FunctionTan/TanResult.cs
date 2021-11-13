using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionTan;

public record TanResult : IndicatorBase
{
    public TanResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}