using TechnicalAnalysis.Candles.CandleShortLine;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleShortLineResult CdlShortLine(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleShortLine(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleShortLineResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleShortLineResult CdlShortLine(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlShortLine(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
