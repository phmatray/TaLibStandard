using TechnicalAnalysis.Candles.CandleEveningDojiStar;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleEveningDojiStarResult CdlEveningDojiStar(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
    {
        return new CandleEveningDojiStar(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }

    public static CandleEveningDojiStarResult CdlEveningDojiStar(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return CdlEveningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
    }

    public static CandleEveningDojiStarResult CdlEveningDojiStar(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
    {
        return CdlEveningDojiStar(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
    }

    public static CandleEveningDojiStarResult CdlEveningDojiStar(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlEveningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
    }
}
