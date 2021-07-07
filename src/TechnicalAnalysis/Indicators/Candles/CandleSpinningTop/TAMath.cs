using TechnicalAnalysis.Candles.CandleSpinningTop;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleSpinningTopResult CdlSpinningTop(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleSpinningTop(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleSpinningTopResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleSpinningTopResult CdlSpinningTop(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlSpinningTop(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
