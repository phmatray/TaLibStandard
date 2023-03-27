using System.Linq;
using static System.Math;

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents an abstract base class for candlestick pattern recognition indicators.
/// </summary>
public abstract class CandleIndicator
{
    /// <summary>
    /// An array of open prices.
    /// </summary>
    protected double[] _open;
        
    /// <summary>
    /// An array of high prices.
    /// </summary>
    protected double[] _high;
        
    /// <summary>
    /// An array of low prices.
    /// </summary>
    protected double[] _low;
        
    /// <summary>
    /// An array of close prices.
    /// </summary>
    protected double[] _close;
        
    /// <summary>
    /// Initializes a new instance of the CandleIndicator class.
    /// </summary>
    /// <param name="open">An array of open prices.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of close prices.</param>
    protected CandleIndicator(double[] open, double[] high, double[] low, double[] close)
    {
        _open = open;
        _high = high;
        _low = low;
        _close = close;
    }
        
    /// <summary>
    /// Returns the lookback period for the indicator.
    /// </summary>
    /// <returns>An integer representing the lookback period.</returns>
    public abstract int GetLookback();
        
    /// <summary>
    /// Checks if the pattern is recognized at a specific index.
    /// </summary>
    /// <param name="i">The index to check for pattern recognition.</param>
    /// <returns>True if the pattern is recognized, false otherwise.</returns>
    public abstract bool GetPatternRecognition(int i);
        
    /// <summary>
    /// Gets the range type of the specified candle setting.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the range type for.</param>
    /// <returns>A RangeType value representing the range type.</returns>
    protected virtual RangeType GetCandleRangeType(CandleSettingType candleSettingType)
        => TACore.Globals.candleSettings[(int)candleSettingType].rangeType;
        
    /// <summary>
    /// Gets the average period of the specified candle setting.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the average period for.</param>
    /// <returns>An integer representing the average period.</returns>
    protected virtual int GetCandleAvgPeriod(CandleSettingType candleSettingType)
        => TACore.Globals.candleSettings[(int)candleSettingType].avgPeriod;
        
    /// <summary>
    /// Gets the factor of the specified candle setting.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the factor for.</param>
    /// <returns>A double representing the factor.</returns>
    protected virtual double GetCandleFactor(CandleSettingType candleSettingType)
        => TACore.Globals.candleSettings[(int)candleSettingType].factor;
        
    /// <summary>
    /// Gets the candle range of the specified candle setting at a specific index.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the range for.</param>
    /// <param name="index">The index to get the range for.</param>
    /// <returns>A double representing the candle range.</returns>
    protected virtual double GetCandleRange(CandleSettingType candleSettingType, int index)
    {
        return GetCandleRangeType(candleSettingType) switch
        {
            RangeType.RealBody => GetRealBody(index),
            RangeType.HighLow => GetHighLowRange(index),
            RangeType.Shadows => GetUpperShadow(index) + GetLowerShadow(index),
            _ => 0.0
        };
    }

    /// <summary>
    /// Gets the candle average of the specified candle setting at a specific index.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the average for.</param>
    /// <param name="sum">The sum of the specified range of elements in the series.</param>
    /// <param name="index">The index to get the average for.</param>
    /// <returns>A double representing the candle average.</returns>
    protected virtual double GetCandleAverage(CandleSettingType candleSettingType, double sum, int index)
    {
        return GetCandleFactor(candleSettingType)
               * (GetCandleAvgPeriod(candleSettingType) != 0.0
                   ? sum / GetCandleAvgPeriod(candleSettingType)
                   : GetCandleRange(candleSettingType, index))
               / (GetCandleRangeType(candleSettingType) == RangeType.Shadows ? 2.0 : 1.0);
    }

    /// <summary>
    /// Gets the real body of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the real body for.</param>
    /// <returns>A double representing the real body.</returns>
    protected virtual double GetRealBody(int index)
        => Abs(_close[index] - _open[index]);

    /// <summary>
    /// Gets the upper shadow of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the upper shadow for.</param>
    /// <returns>A double representing the upper shadow.</returns>
    protected virtual double GetUpperShadow(int index)
        => _high[index] - (_close[index] >= _open[index] ? _close[index] : _open[index]);

    /// <summary>
    /// Gets the lower shadow of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the lower shadow for.</param>
    /// <returns>A double representing the lower shadow.</returns>
    protected virtual double GetLowerShadow(int index)
        => (_close[index] >= _open[index] ? _open[index] : _close[index]) - _low[index];

    /// <summary>
    /// Gets the high-low range of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the high-low range for.</param>
    /// <returns>A double representing the high-low range.</returns>
    protected virtual double GetHighLowRange(int index)
        => _high[index] - _low[index];

    /// <summary>
    /// Gets the color of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the candle color for.</param>
    /// <returns>1 if the candle is bullish, -1 if the candle is bearish.</returns>
    protected virtual int GetCandleColor(int index)
        => _close[index] >= _open[index] ? 1 : -1;

    /// <summary>
    /// Checks if there is a real body gap up between two candles.
    /// </summary>
    /// <param name="index2">The index of the second candle.</param>
    /// <param name="index1">The index of the first candle.</param>
    /// <returns>True if there is a real body gap up, false otherwise.</returns>
    protected virtual bool GetRealBodyGapUp(int index2, int index1)
        => Min(_open[index2], _close[index2]) > Max(_open[index1], _close[index1]);

    /// <summary>
    /// Checks if there is a real body gap down between two candles.
    /// </summary>
    /// <param name="index2">The index of the second candle.</param>
    /// <param name="index1">The index of the first candle.</param>
    /// <returns>True if there is a real body gap down, false otherwise.</returns>
    protected virtual bool GetRealBodyGapDown(int index2, int index1)
        => Max(_open[index2], _close[index2]) < Min(_open[index1], _close[index1]);

    /// <summary>
    /// Checks if there is a candle gap up between two candles.
    /// </summary>
    /// <param name="index2">The index of the second candle.</param>
    /// <param name="index1">The index of the first candle.</param>
    /// <returns>True if there is a candle gap up, false otherwise.</returns>
    protected virtual bool GetCandleGapUp(int index2, int index1)
        => _low[index2] > _high[index1];

    /// <summary>
    /// Checks if there is a candle gap down between two candles.
    /// </summary>
    /// <param name="index2">The index of the second candle.</param>
    /// <param name="index1">The index of the first candle.</param>
    /// <returns>True if there is a candle gap down, false otherwise.</returns>
    protected virtual bool GetCandleGapDown(int index2, int index1)
        => _high[index2] < _low[index1];

    /// <summary>
    /// Gets the maximum average period among the specified candle settings.
    /// </summary>
    /// <param name="candleSettingTypes">An array of candle setting types to get the maximum average period for.</param>
    /// <returns>An integer representing the maximum average period.</returns>
    protected virtual int GetCandleMaxAvgPeriod(params CandleSettingType[] candleSettingTypes)
        => candleSettingTypes
            .Select(GetCandleAvgPeriod)
            .Aggregate(Max);
}
