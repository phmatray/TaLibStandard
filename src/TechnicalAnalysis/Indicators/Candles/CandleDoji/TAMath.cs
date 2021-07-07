using TechnicalAnalysis.Candles.CandleDoji;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleDojiResult CdlDoji(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleDoji(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleDojiResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleDojiResult CdlDoji(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlDoji(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
