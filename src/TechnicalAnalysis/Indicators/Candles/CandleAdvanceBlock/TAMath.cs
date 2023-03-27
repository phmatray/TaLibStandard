using TechnicalAnalysis.Candles.CandleAdvanceBlock;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleAdvanceBlockResult CdlAdvanceBlock(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleAdvanceBlock(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleAdvanceBlockResult CdlAdvanceBlock(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlAdvanceBlock(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
