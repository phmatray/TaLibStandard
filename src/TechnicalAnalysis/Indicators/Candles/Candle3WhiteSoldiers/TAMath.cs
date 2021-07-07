using TechnicalAnalysis.Candles.Candle3WhiteSoldiers;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Candle3WhiteSoldiersResult Cdl3WhiteSoldiers(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new Candle3WhiteSoldiers(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new Candle3WhiteSoldiersResult(retCode, begIdx, nbElement, ints);
        }

        public static Candle3WhiteSoldiersResult Cdl3WhiteSoldiers(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl3WhiteSoldiers(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
