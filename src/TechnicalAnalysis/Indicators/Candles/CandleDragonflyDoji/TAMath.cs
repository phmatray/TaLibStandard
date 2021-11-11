using TechnicalAnalysis.Candles.CandleDragonflyDoji;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleDragonflyDojiResult CdlDragonflyDoji(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleDragonflyDoji(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleDragonflyDojiResult CdlDragonflyDoji(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlDragonflyDoji(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}