// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents a setting for a candlestick pattern in technical analysis.
/// </summary>
/// <param name="settingType">The type of the candlestick setting.</param>
/// <param name="rangeType">The type of the range to consider for the setting.</param>
/// <param name="avgPeriod">The average period to consider for the setting.</param>
/// <param name="factor">The factor to consider for the setting.</param>
public sealed class CandleSetting(
    CandleSettingType settingType,
    RangeType rangeType,
    int avgPeriod,
    double factor)
{
    /// <summary>
    /// Gets the type of the candlestick setting.
    /// </summary>
    public CandleSettingType SettingType { get; } = settingType;

    /// <summary>
    /// Gets the type of the range to consider for the setting.
    /// </summary>
    public RangeType RangeType { get; } = rangeType;

    /// <summary>
    /// Gets the average period to consider for the setting.
    /// </summary>
    public int AvgPeriod { get; } = avgPeriod;

    /// <summary>
    /// Gets the factor to consider for the setting.
    /// </summary>
    public double Factor { get; } = factor;

    /// <summary>
    /// Gets the default setting for a given type.
    /// </summary>
    /// <param name="settingType">The type of the candlestick setting.</param>
    /// <returns>The default setting for the given type.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the setting type is AllCandleSettings.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the setting type is not recognized.</exception>
    public static CandleSetting GetDefaultByType(CandleSettingType settingType)
        => settingType switch
        {
            BodyLong          => DefaultBodyLong,
            BodyVeryLong      => DefaultBodyVeryLong,
            BodyShort         => DefaultBodyShort,
            BodyDoji          => DefaultBodyDoji,
            ShadowLong        => DefaultShadowLong,
            ShadowVeryLong    => DefaultShadowVeryLong,
            ShadowShort       => DefaultShadowShort,
            ShadowVeryShort   => DefaultShadowVeryShort,
            Near              => DefaultNear,
            Far               => DefaultFar,
            Equal             => DefaultEqual,
            AllCandleSettings => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException(nameof(settingType), settingType, null)
        };

    /// <summary>
    /// Gets the default setting for a long body.
    /// </summary>
    public static CandleSetting DefaultBodyLong
        => new(BodyLong, RangeType.RealBody, 10, 1.0);
    
    /// <summary>
    /// Gets the default setting for a very long body.
    /// </summary>
    public static CandleSetting DefaultBodyVeryLong
        => new(BodyVeryLong, RangeType.RealBody, 10, 3.0);
    
    /// <summary>
    /// Gets the default setting for a short body.
    /// </summary>
    public static CandleSetting DefaultBodyShort
        => new(BodyShort, RangeType.RealBody, 10, 1.0);
    
    /// <summary>
    /// Gets the default setting for a doji body.
    /// </summary>
    public static CandleSetting DefaultBodyDoji
        => new(BodyDoji, RangeType.HighLow, 10, 0.1);
    
    /// <summary>
    /// Gets the default setting for a long shadow.
    /// </summary>
    public static CandleSetting DefaultShadowLong
        => new(ShadowLong, RangeType.RealBody, 0, 1.0);
    
    /// <summary>
    /// Gets the default setting for a very long shadow.
    /// </summary>
    public static CandleSetting DefaultShadowVeryLong
        => new(ShadowVeryLong, RangeType.RealBody, 0, 2.0);
    
    /// <summary>
    /// Gets the default setting for a short shadow.
    /// </summary>
    public static CandleSetting DefaultShadowShort
        => new(ShadowShort, RangeType.Shadows, 10, 1.0);
    
    /// <summary>
    /// Gets the default setting for a very short shadow.
    /// </summary>
    public static CandleSetting DefaultShadowVeryShort
        => new(ShadowVeryShort, RangeType.HighLow, 10, 0.1);
    
    /// <summary>
    /// Gets the default setting for a near range.
    /// </summary>
    public static CandleSetting DefaultNear
        => new(Near, RangeType.HighLow, 5, 0.2);
    
    /// <summary>
    /// Gets the default setting for a far range.
    /// </summary>
    public static CandleSetting DefaultFar
        => new(Far, RangeType.HighLow, 5, 0.6);
    
    /// <summary>
    /// Gets the default setting for an equal range.
    /// </summary>
    public static CandleSetting DefaultEqual
        => new(Equal, RangeType.HighLow, 5, 0.05);
}
