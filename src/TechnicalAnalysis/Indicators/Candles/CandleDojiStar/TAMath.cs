using TechnicalAnalysis.Candles.CandleDojiStar;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleDojiStarResult CdlDojiStar(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return new CandleDojiStar(open, high, low, close)
            .Compute(startIdx, endIdx);
    }

    public static CandleDojiStarResult CdlDojiStar(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlDojiStar(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }
}