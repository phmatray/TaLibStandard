using TechnicalAnalysis.Candles.CandleThrusting;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleThrustingResult CdlThrusting(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleThrusting(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleThrustingResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleThrustingResult CdlThrusting(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlThrusting(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
