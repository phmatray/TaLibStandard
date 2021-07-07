using TechnicalAnalysis.Candles.CandleLongLine;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleLongLineResult CdlLongLine(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleLongLine(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleLongLineResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleLongLineResult CdlLongLine(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlLongLine(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
