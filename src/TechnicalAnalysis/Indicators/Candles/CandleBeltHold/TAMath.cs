using TechnicalAnalysis.Candles.CandleBeltHold;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleBeltHoldResult CdlBeltHold(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleBeltHold(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleBeltHoldResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleBeltHoldResult CdlBeltHold(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlBeltHold(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
