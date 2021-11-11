using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record StochFResult : IndicatorBase
{
    public StochFResult(RetCode retCode, int begIdx, int nbElement, double[] fastK, double[] fastD)
        : base(retCode, begIdx, nbElement)
    {
        FastK = fastK;
        FastD = fastD;
    }

    public double[] FastD { get; }

    public double[] FastK { get; }
}