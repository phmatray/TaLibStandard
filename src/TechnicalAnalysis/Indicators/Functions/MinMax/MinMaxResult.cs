using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public record MinMaxResult : IndicatorBase
    {
        public MinMaxResult(RetCode retCode, int begIdx, int nbElement, double[] min, double[] max)
            : base(retCode, begIdx, nbElement)
        {
            Min = min;
            Max = max;
        }

        public double[] Max { get; }

        public double[] Min { get; }
    }
}
