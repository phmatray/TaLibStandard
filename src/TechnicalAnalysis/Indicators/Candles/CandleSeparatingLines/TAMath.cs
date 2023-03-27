using TechnicalAnalysis.Candles.CandleSeparatingLines;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleSeparatingLinesResult CdlSeparatingLines(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleSeparatingLines(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleSeparatingLinesResult CdlSeparatingLines(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlSeparatingLines(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}
