using TechnicalAnalysis.Candles.CandleMorningDojiStar;
using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static CandleMorningDojiStarResult CdlMorningDojiStar(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
    {
        return new CandleMorningDojiStar(open, high, low, close)
            .Compute(startIdx, endIdx, penetration);
    }

    public static CandleMorningDojiStarResult CdlMorningDojiStar(
        int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
    {
        return CdlMorningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
    }

    public static CandleMorningDojiStarResult CdlMorningDojiStar(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
    {
        return CdlMorningDojiStar(startIdx, endIdx,
            open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
    }

    public static CandleMorningDojiStarResult CdlMorningDojiStar(
        int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
    {
        return CdlMorningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
    }
}
