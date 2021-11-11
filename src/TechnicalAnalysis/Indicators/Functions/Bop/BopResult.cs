using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record BopResult : IndicatorBase
{
    public BopResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}