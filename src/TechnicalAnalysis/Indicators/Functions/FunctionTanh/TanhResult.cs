using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionTanh;

public record TanhResult : IndicatorBase
{
    public TanhResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}