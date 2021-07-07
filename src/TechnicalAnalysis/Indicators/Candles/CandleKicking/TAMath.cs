using TechnicalAnalysis.Candles.CandleKicking;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleKickingResult CdlKicking(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleKicking(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleKickingResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleKickingResult CdlKicking(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlKicking(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
