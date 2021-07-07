using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static AroonResult Aroon(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outAroonDown = new double[endIdx - startIdx + 1];
            double[] outAroonUp = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Aroon(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outAroonDown,
                ref outAroonUp);
            
            return new AroonResult(retCode, outBegIdx, outNBElement, outAroonDown, outAroonUp);
        }

        public static AroonResult Aroon(int startIdx, int endIdx, double[] high, double[] low)
            => Aroon(startIdx, endIdx, high, low, 14);

        public static AroonResult Aroon(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
            => Aroon(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

        public static AroonResult Aroon(int startIdx, int endIdx, float[] high, float[] low)
            => Aroon(startIdx, endIdx, high, low, 14);
    }

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
