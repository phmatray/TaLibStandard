using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public record AdxrResult : IndicatorBase
    {
        public AdxrResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
