// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using static System.Math;

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents an abstract base class for candlestick pattern recognition indicators.
/// </summary>
public abstract class CandleIndicator<T>
    where T : IFloatingPoint<T>
{
    /// <summary>
    /// An array of open prices.
    /// </summary>
    protected T[] Open { get; }
        
    /// <summary>
    /// An array of high prices.
    /// </summary>
    protected T[] High { get; }
        
    /// <summary>
    /// An array of low prices.
    /// </summary>
    protected T[] Low { get; }
        
    /// <summary>
    /// An array of close prices.
    /// </summary>
    protected T[] Close { get; }
        
    /// <summary>
    /// Initializes a new instance of the CandleIndicator class.
    /// </summary>
    /// <param name="open">An array of open prices.</param>
    /// <param name="high">An array of high prices.</param>
    /// <param name="low">An array of low prices.</param>
    /// <param name="close">An array of close prices.</param>
    protected CandleIndicator(T[] open, T[] high, T[] low, T[] close)
    {
        Open = open;
        High = high;
        Low = low;
        Close = close;
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
    /// Prepares the output variables.
    /// </summary>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    /// <returns>A tuple containing the output variables.</returns>
    protected virtual (int outBegIdx, int outNBElement, int[] outInteger) PrepareOutput(int startIdx, int endIdx)
    {
        // Initialize output variables
        int outBegIdx = 0;
        int outNBElement = 0;
        
        // Ensure we don't create an array with negative size
        int arraySize = Math.Max(0, endIdx - startIdx + 1);
        int[] outInteger = new int[arraySize];
        
        // Return the output variables.
        return (outBegIdx, outNBElement, outInteger);
    }
    
    /// <summary>
    /// Validates the specified indices.
    /// </summary>
    /// <param name="startIdx">The start index.</param>
    /// <param name="endIdx">The end index.</param>
    protected virtual void ValidateIndices(ref int startIdx, ref int endIdx)
    {
        // Validate the requested output range.
        ArgumentOutOfRangeException.ThrowIfNegative(startIdx);
        
        // Check if endIdx is less than startIdx before doing the subtraction
        if (endIdx < startIdx)
        {
            throw new ArgumentOutOfRangeException(nameof(endIdx), 
                $"endIdx - startIdx ('{endIdx - startIdx}') must be a non-negative value.");
        }
    }
    
    /// <summary>
    /// Validates the price arrays.
    /// </summary>
    protected virtual void ValidatePriceArrays()
    {
        // Verify required price component.
        ArgumentNullException.ThrowIfNull(Open);
        ArgumentNullException.ThrowIfNull(High);
        ArgumentNullException.ThrowIfNull(Low);
        ArgumentNullException.ThrowIfNull(Close);
    }
    
    /// <summary>
    /// Validates the specified parameters.
    /// </summary>
    /// <param name="penetration">The penetration to validate.</param>
    protected virtual void ValidateParameters(T penetration)
    {
        // Verify parameters
        ArgumentOutOfRangeException.ThrowIfNegative(penetration);
    }
    
    /// <summary>
    /// Gets the range type of the specified candle setting.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the range type for.</param>
    /// <returns>A RangeType value representing the range type.</returns>
    protected virtual RangeType GetCandleRangeType(CandleSettingType candleSettingType)
        => TACore.Globals.CandleSettings[candleSettingType].RangeType;
        
    /// <summary>
    /// Gets the average period of the specified candle setting.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the average period for.</param>
    /// <returns>An integer representing the average period.</returns>
    protected virtual int GetCandleAvgPeriod(CandleSettingType candleSettingType)
        => TACore.Globals.CandleSettings[candleSettingType].AvgPeriod;
        
    /// <summary>
    /// Gets the factor of the specified candle setting.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the factor for.</param>
    /// <returns>A double representing the factor.</returns>
    protected virtual double GetCandleFactor(CandleSettingType candleSettingType)
        => TACore.Globals.CandleSettings[candleSettingType].Factor;
        
    /// <summary>
    /// Gets the candle range of the specified candle setting at a specific index.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the range for.</param>
    /// <param name="index">The index to get the range for.</param>
    /// <returns>A double representing the candle range.</returns>
    protected virtual T GetCandleRange(CandleSettingType candleSettingType, int index)
    {
        return GetCandleRangeType(candleSettingType) switch
        {
            RangeType.RealBody => GetRealBody(index),
            RangeType.HighLow => GetHighLowRange(index),
            RangeType.Shadows => GetUpperShadow(index) + GetLowerShadow(index),
            _ => T.CreateChecked(0.0)
        };
    }

    /// <summary>
    /// Gets the candle average of the specified candle setting at a specific index.
    /// </summary>
    /// <param name="candleSettingType">The candle setting type to get the average for.</param>
    /// <param name="sum">The sum of the specified range of elements in the series.</param>
    /// <param name="index">The index to get the average for.</param>
    /// <returns>A double representing the candle average.</returns>
    protected virtual T GetCandleAverage(CandleSettingType candleSettingType, T sum, int index)
    { 
        T candleAvgPeriod = T.CreateChecked(GetCandleAvgPeriod(candleSettingType));
        T candleFactor = T.CreateChecked(GetCandleFactor(candleSettingType));
        T two = T.CreateChecked(2);
        T one = T.CreateChecked(1);

        return candleFactor
               * (candleAvgPeriod != T.Zero
                   ? sum / candleAvgPeriod
                   : GetCandleRange(candleSettingType, index))
               / (GetCandleRangeType(candleSettingType) == RangeType.Shadows ? two : one);
    }

    /// <summary>
    /// Gets the real body of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the real body for.</param>
    /// <returns>A double representing the real body.</returns>
    protected virtual T GetRealBody(int index)
        => T.Abs(Close[index] - Open[index]);

    /// <summary>
    /// Gets the upper shadow of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the upper shadow for.</param>
    /// <returns>A double representing the upper shadow.</returns>
    protected virtual T GetUpperShadow(int index)
        => High[index] - (Close[index] >= Open[index] ? Close[index] : Open[index]);

    /// <summary>
    /// Gets the lower shadow of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the lower shadow for.</param>
    /// <returns>A double representing the lower shadow.</returns>
    protected virtual T GetLowerShadow(int index)
        => (Close[index] >= Open[index] ? Open[index] : Close[index]) - Low[index];

    /// <summary>
    /// Gets the high-low range of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the high-low range for.</param>
    /// <returns>A double representing the high-low range.</returns>
    protected virtual T GetHighLowRange(int index)
        => High[index] - Low[index];

    /// <summary>
    /// Gets the color of the candle at a specific index.
    /// </summary>
    /// <param name="index">The index to get the candle color for.</param>
    /// <returns>1 if the candle is bullish, -1 if the candle is bearish.</returns>
    protected virtual CandleColor GetCandleColor(int index)
        => Close[index] >= Open[index] ? CandleColor.Green : CandleColor.Red;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    protected virtual bool IsColorGreen(int index)
        => GetCandleColor(index) == CandleColor.Green;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    protected virtual bool IsColorRed(int index)
        => GetCandleColor(index) == CandleColor.Red;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index2"></param>
    /// <param name="index1"></param>
    /// <returns></returns>
    protected virtual bool IsColorSame(int index2, int index1)
        => GetCandleColor(index2) == GetCandleColor(index1);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index2"></param>
    /// <param name="index1"></param>
    /// <returns></returns>
    protected virtual bool IsColorOpposite(int index2, int index1)
        => (int)GetCandleColor(index2) == -(int)GetCandleColor(index1);

    /// <summary>
    /// Checks if there is a real body gap up between two candles.
    /// </summary>
    /// <param name="index2">The index of the second candle.</param>
    /// <param name="index1">The index of the first candle.</param>
    /// <returns>True if there is a real body gap up, false otherwise.</returns>
    protected virtual bool GetRealBodyGapUp(int index2, int index1)
        => T.Min(Open[index2], Close[index2]) > T.Max(Open[index1], Close[index1]);

    /// <summary>
    /// Checks if there is a real body gap down between two candles.
    /// </summary>
    /// <param name="index2">The index of the second candle.</param>
    /// <param name="index1">The index of the first candle.</param>
    /// <returns>True if there is a real body gap down, false otherwise.</returns>
    protected virtual bool GetRealBodyGapDown(int index2, int index1)
        => T.Max(Open[index2], Close[index2]) < T.Min(Open[index1], Close[index1]);

    /// <summary>
    /// Checks if there is a candle gap up between two candles.
    /// </summary>
    /// <param name="index2">The index of the second candle.</param>
    /// <param name="index1">The index of the first candle.</param>
    /// <returns>True if there is a candle gap up, false otherwise.</returns>
    protected virtual bool GetCandleGapUp(int index2, int index1)
        => Low[index2] > High[index1];

    /// <summary>
    /// Checks if there is a candle gap down between two candles.
    /// </summary>
    /// <param name="index2">The index of the second candle.</param>
    /// <param name="index1">The index of the first candle.</param>
    /// <returns>True if there is a candle gap down, false otherwise.</returns>
    protected virtual bool GetCandleGapDown(int index2, int index1)
        => High[index2] < Low[index1];

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
