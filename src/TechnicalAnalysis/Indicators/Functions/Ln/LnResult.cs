using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record LnResult : IndicatorBase
{
    public LnResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}
