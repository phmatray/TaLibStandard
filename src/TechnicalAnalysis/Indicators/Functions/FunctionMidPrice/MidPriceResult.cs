using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMidPrice;

public record MidPriceResult : IndicatorBase
{
    public MidPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}