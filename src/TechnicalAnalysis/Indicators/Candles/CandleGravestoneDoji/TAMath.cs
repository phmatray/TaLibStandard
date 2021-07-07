using TechnicalAnalysis.Candles.CandleGravestoneDoji;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleGravestoneDojiResult CdlGravestoneDoji(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleGravestoneDoji(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleGravestoneDojiResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleGravestoneDojiResult CdlGravestoneDoji(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlGravestoneDoji(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
