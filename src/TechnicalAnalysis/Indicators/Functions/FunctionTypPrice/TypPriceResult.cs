using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionTypPrice;

public record TypPriceResult : IndicatorBase
{
    public TypPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}