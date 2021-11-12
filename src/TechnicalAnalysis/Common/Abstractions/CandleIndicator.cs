using static System.Math;

namespace TechnicalAnalysis.Common;

public abstract class CandleIndicator
{
    /// <summary>
    /// The price at which the first transaction was completed in a given time period.
    /// </summary>
    protected double[] Open { get; }

    /// <summary>
    /// Top bid or price at which a contract was traded during a trading period.
    /// </summary>
    protected double[] High { get; }

    /// <summary>
    /// Lowest offer or price at which a contract was traded during a trading period.
    /// </summary>
    protected double[] Low { get; }

    /// <summary>
    /// This is the last traded price in the market for the specified session.
    /// </summary>
    protected double[] Close { get; }

    /// <summary>
    /// Constructor for <see cref="CandleIndicator"/> class.
    /// </summary>
    /// <param name="open">The price at which the first transaction was completed in a given time period.</param>
    /// <param name="high">Top bid or price at which a contract was traded during a trading period.</param>
    /// <param name="low">Lowest offer or price at which a contract was traded during a trading period.</param>
    /// <param name="close">This is the last traded price in the market for the specified session.</param>
    protected CandleIndicator(double[] open, double[] high, double[] low, double[] close)
    {
        Open = open;
        High = high;
        Low = low;
        Close = close;
    }

    public abstract int GetLookback();
    public abstract bool GetPatternRecognition(int i);

    protected RangeType GetCandleRangeType(CandleSettingType candleSettingType)
        => TACore.Globals.candleSettings[(int)candleSettingType].rangeType;

    protected int GetCandleAvgPeriod(CandleSettingType candleSettingType)
        => TACore.Globals.candleSettings[(int)candleSettingType].avgPeriod;

    protected double GetCandleFactor(CandleSettingType candleSettingType)
        => TACore.Globals.candleSettings[(int)candleSettingType].factor;

    protected double GetCandleRange(CandleSettingType candleSettingType, int index)
    {
        return GetCandleRangeType(candleSettingType) switch
        {
            RangeType.RealBody => GetRealBody(index),
            RangeType.HighLow => GetHighLowRange(index),
            RangeType.Shadows => GetUpperShadow(index) + GetLowerShadow(index),
            _ => 0.0
        };
    }

    protected double GetCandleAverage(CandleSettingType candleSettingType, double sum, int index)
    {
        return GetCandleFactor(candleSettingType)
               * (GetCandleAvgPeriod(candleSettingType) != 0.0
                   ? sum / GetCandleAvgPeriod(candleSettingType)
                   : GetCandleRange(candleSettingType, index))
               / (GetCandleRangeType(candleSettingType) == RangeType.Shadows ? 2.0 : 1.0);
    }

    protected double GetRealBody(int index)
        => Abs(Close[index] - Open[index]);

    protected double GetUpperShadow(int index)
        => High[index] - (Close[index] >= Open[index] ? Close[index] : Open[index]);

    protected double GetLowerShadow(int index)
        => (Close[index] >= Open[index] ? Open[index] : Close[index]) - Low[index];

    protected double GetHighLowRange(int index)
        => High[index] - Low[index];

    protected int GetCandleColor(int index)
        => Close[index] >= Open[index] ? 1 : -1;

    protected bool GetRealBodyGapUp(int index2, int index1)
        => Min(Open[index2], Close[index2]) > Max(Open[index1], Close[index1]);

    protected bool GetRealBodyGapDown(int index2, int index1)
        => Max(Open[index2], Close[index2]) < Min(Open[index1], Close[index1]);

    protected bool GetCandleGapUp(int index2, int index1)
        => Low[index2] > High[index1];

    protected bool GetCandleGapDown(int index2, int index1)
        => High[index2] < Low[index1];

    protected int GetCandleMaxAvgPeriod(params CandleSettingType[] candleSettingTypes)
        => candleSettingTypes
            .Select(GetCandleAvgPeriod)
            .Aggregate(Max);
}
