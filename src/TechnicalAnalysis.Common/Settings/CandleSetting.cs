// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

public sealed class CandleSetting
{
    public CandleSettingType SettingType { get; }
    public RangeType RangeType { get; }
    public int AvgPeriod { get; }
    public double Factor { get; }

    public CandleSetting(CandleSettingType settingType, RangeType rangeType, int avgPeriod, double factor)
    {
        SettingType = settingType;
        RangeType = rangeType;
        AvgPeriod = avgPeriod;
        Factor = factor;
    }
    
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
    
    public static CandleSetting DefaultBodyLong
        => new(BodyLong, RangeType.RealBody, 10, 1.0);
    
    public static CandleSetting DefaultBodyVeryLong
        => new(BodyVeryLong, RangeType.RealBody, 10, 3.0);
    
    public static CandleSetting DefaultBodyShort
        => new(BodyShort, RangeType.RealBody, 10, 1.0);
    
    public static CandleSetting DefaultBodyDoji
        => new(BodyDoji, RangeType.HighLow, 10, 0.1);
    
    public static CandleSetting DefaultShadowLong
        => new(ShadowLong, RangeType.RealBody, 0, 1.0);
    
    public static CandleSetting DefaultShadowVeryLong
        => new(ShadowVeryLong, RangeType.RealBody, 0, 2.0);
    
    public static CandleSetting DefaultShadowShort
        => new(ShadowShort, RangeType.Shadows, 10, 1.0);
    
    public static CandleSetting DefaultShadowVeryShort
        => new(ShadowVeryShort, RangeType.HighLow, 10, 0.1);
    
    public static CandleSetting DefaultNear
        => new(Near, RangeType.HighLow, 5, 0.2);
    
    public static CandleSetting DefaultFar
        => new(Far, RangeType.HighLow, 5, 0.6);
    
    public static CandleSetting DefaultEqual
        => new(Equal, RangeType.HighLow, 5, 0.05);
}
