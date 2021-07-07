using TechnicalAnalysis.Candles.CandleLadderBottom;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleLadderBottomResult CdlLadderBottom(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleLadderBottom(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleLadderBottomResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleLadderBottomResult CdlLadderBottom(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlLadderBottom(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
