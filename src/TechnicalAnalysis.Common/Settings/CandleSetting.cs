// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

/// <summary>
/// 
/// </summary>
public sealed class CandleSetting
{
    /// <summary>
    /// 
    /// </summary>
    public CandleSettingType SettingType { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public RangeType RangeType { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public int AvgPeriod { get; }
    
    /// <summary>
    /// 
    /// </summary>
    public double Factor { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="settingType"></param>
    /// <param name="rangeType"></param>
    /// <param name="avgPeriod"></param>
    /// <param name="factor"></param>
    public CandleSetting(CandleSettingType settingType, RangeType rangeType, int avgPeriod, double factor)
    {
        SettingType = settingType;
        RangeType = rangeType;
        AvgPeriod = avgPeriod;
        Factor = factor;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="settingType"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static CandleSetting GetDefaultByType(CandleSettingType settingType)
    {
        return settingType switch
        {
            BodyLong => DefaultBodyLong,
            BodyVeryLong => DefaultBodyVeryLong,
            BodyShort => DefaultBodyShort,
            BodyDoji => DefaultBodyDoji,
            ShadowLong => DefaultShadowLong,
            ShadowVeryLong => DefaultShadowVeryLong,
            ShadowShort => DefaultShadowShort,
            ShadowVeryShort => DefaultShadowVeryShort,
            Near => DefaultNear,
            Far => DefaultFar,
            Equal => DefaultEqual,
            AllCandleSettings => throw new InvalidOperationException(),
            _ => throw new ArgumentOutOfRangeException(nameof(settingType), settingType, null)
        };
    }
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultBodyLong
        => new(BodyLong, RangeType.RealBody, 10, 1.0);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultBodyVeryLong
        => new(BodyVeryLong, RangeType.RealBody, 10, 3.0);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultBodyShort
        => new(BodyShort, RangeType.RealBody, 10, 1.0);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultBodyDoji
        => new(BodyDoji, RangeType.HighLow, 10, 0.1);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultShadowLong
        => new(ShadowLong, RangeType.RealBody, 0, 1.0);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultShadowVeryLong
        => new(ShadowVeryLong, RangeType.RealBody, 0, 2.0);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultShadowShort
        => new(ShadowShort, RangeType.Shadows, 10, 1.0);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultShadowVeryShort
        => new(ShadowVeryShort, RangeType.HighLow, 10, 0.1);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultNear
        => new(Near, RangeType.HighLow, 5, 0.2);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultFar
        => new(Far, RangeType.HighLow, 5, 0.6);
    
    /// <summary>
    /// 
    /// </summary>
    public static CandleSetting DefaultEqual
        => new(Equal, RangeType.HighLow, 5, 0.05);
}
