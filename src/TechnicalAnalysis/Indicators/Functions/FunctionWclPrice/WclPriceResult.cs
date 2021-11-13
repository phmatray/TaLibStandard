using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionWclPrice;

public record WclPriceResult : IndicatorBase
{
    public WclPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}