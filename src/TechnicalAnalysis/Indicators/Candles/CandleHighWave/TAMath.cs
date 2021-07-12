using TechnicalAnalysis.Candles.CandleHighWave;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CandleHighWaveResult CdlHighWave(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return new CandleHighWave(open, high, low, close)
                .Compute(startIdx, endIdx);
        }

        public static CandleHighWaveResult CdlHighWave(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlHighWave(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }
}
