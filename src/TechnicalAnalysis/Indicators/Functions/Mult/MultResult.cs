using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record MultResult : IndicatorBase
{
    public MultResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}
