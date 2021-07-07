using TechnicalAnalysis.Candles.Candle3StarsInSouth;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Candle3StarsInSouthResult Cdl3StarsInSouth(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new Candle3StarsInSouth(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new Candle3StarsInSouthResult(retCode, begIdx, nbElement, ints);
        }

        public static Candle3StarsInSouthResult Cdl3StarsInSouth(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl3StarsInSouth(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
