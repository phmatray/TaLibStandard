using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public record StochRsiResult : IndicatorBase
    {
        public StochRsiResult(RetCode retCode, int begIdx, int nbElement, double[] fastK, double[] fastD)
            : base(retCode, begIdx, nbElement)
        {
            FastK = fastK;
            FastD = fastD;
        }

        public double[] FastD { get; }

        public double[] FastK { get; }
    }
}
