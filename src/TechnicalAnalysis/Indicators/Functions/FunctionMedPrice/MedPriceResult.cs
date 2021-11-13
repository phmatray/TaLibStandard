using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMedPrice;

public record MedPriceResult : IndicatorBase
{
    public MedPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}