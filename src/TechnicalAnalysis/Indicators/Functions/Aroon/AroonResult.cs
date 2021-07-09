using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public record AroonResult : IndicatorBase
    {
        public AroonResult(RetCode retCode, int begIdx, int nbElement, double[] aroonDown, double[] aroonUp)
            : base(retCode, begIdx, nbElement)
        {
            AroonDown = aroonDown;
            AroonUp = aroonUp;
        }

        public double[] AroonDown { get; }

        public double[] AroonUp { get; }
    }
}
