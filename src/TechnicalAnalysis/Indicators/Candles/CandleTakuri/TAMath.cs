using TechnicalAnalysis.Candles.CandleTakuri;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleTakuriResult CdlTakuri(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleTakuri(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleTakuriResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleTakuriResult CdlTakuri(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlTakuri(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
