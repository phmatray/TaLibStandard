using TechnicalAnalysis.Candles.CandlePiercing;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandlePiercingResult CdlPiercing(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandlePiercing(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandlePiercingResult(retCode, begIdx, nbElement, ints);
        }

        public static CandlePiercingResult CdlPiercing(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlPiercing(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
