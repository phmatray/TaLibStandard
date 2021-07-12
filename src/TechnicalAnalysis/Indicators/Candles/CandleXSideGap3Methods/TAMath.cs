using TechnicalAnalysis.Candles.CandleXSideGap3Methods;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleXSideGap3MethodsResult CdlXSideGap3Methods(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleXSideGap3Methods(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleXSideGap3MethodsResult CdlXSideGap3Methods(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlXSideGap3Methods(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
