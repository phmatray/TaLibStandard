using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAd;

public record AdResult : IndicatorBase
{
    public AdResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}