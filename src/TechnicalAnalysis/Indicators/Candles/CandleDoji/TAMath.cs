using TechnicalAnalysis.Candles.CandleDoji;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleDojiResult CdlDoji(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleDoji(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleDojiResult CdlDoji(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlDoji(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
