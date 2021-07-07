using TechnicalAnalysis.Candles.CandleUnique3River;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleUnique3RiverResult CdlUnique3River(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleUnique3River(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleUnique3RiverResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleUnique3RiverResult CdlUnique3River(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlUnique3River(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
