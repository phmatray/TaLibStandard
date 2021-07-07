using TechnicalAnalysis.Candles.CandleRickshawMan;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleRickshawManResult CdlRickshawMan(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleRickshawMan(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CandleRickshawManResult(retCode, begIdx, nbElement, ints);
        }

        public static CandleRickshawManResult CdlRickshawMan(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlRickshawMan(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
