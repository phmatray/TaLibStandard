using TechnicalAnalysis.Candles.Candle3BlackCrows;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Candle3BlackCrowsResult Cdl3BlackCrows(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new Candle3BlackCrows(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new Candle3BlackCrowsResult(retCode, begIdx, nbElement, ints);
        }

        public static Candle3BlackCrowsResult Cdl3BlackCrows(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl3BlackCrows(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
