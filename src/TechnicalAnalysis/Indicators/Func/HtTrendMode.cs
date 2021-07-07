using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtTrendModeResult HtTrendMode(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtTrendMode(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new HtTrendModeResult(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static HtTrendModeResult HtTrendMode(int startIdx, int endIdx, float[] real)
            => HtTrendMode(startIdx, endIdx, real.ToDouble());
    }

    public record HtTrendModeResult : IndicatorBase
    {
        public HtTrendModeResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
