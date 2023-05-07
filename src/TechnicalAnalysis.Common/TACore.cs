// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

public static partial class TACore
{
    public static GlobalsType Globals { get; }

    static TACore()
    {
        Globals = new GlobalsType();
    }
        
    public static Compatibility GetCompatibility()
    {
        return Globals.Compatibility;
    }
        
    public static RetCode SetCompatibility(Compatibility value)
    {
        Globals.Compatibility = value;
        return Success;
    }
        
    public static long GetUnstablePeriod(FuncUnstId id)
    {
        return id >= FuncUnstId.FuncUnstAll ? 0 : Globals.UnstablePeriod[(int)id];
    }
        
    public static RetCode SetUnstablePeriod(FuncUnstId id, long unstablePeriod)
    {
        if (id > FuncUnstId.FuncUnstAll)
        {
            return BadParam;
        }
            
        if (id != FuncUnstId.FuncUnstAll)
        {
            Globals.UnstablePeriod[(int)id] = unstablePeriod;
        }
        else
        {
            for (int i = 0; i < 23; i++)
            {
                Globals.UnstablePeriod[i] = unstablePeriod;
            }
        }
            
        return Success;
    }
        
    public static RetCode RestoreCandleDefaultSettings(CandleSettingType settingType)
    {
        switch (settingType)
        {
            case > AllCandleSettings:
                return BadParam;
            
            case AllCandleSettings:
                SetCandleSettings(CandleSetting.DefaultBodyLong);
                SetCandleSettings(CandleSetting.DefaultBodyVeryLong);
                SetCandleSettings(CandleSetting.DefaultBodyShort);
                SetCandleSettings(CandleSetting.DefaultBodyDoji);
                SetCandleSettings(CandleSetting.DefaultShadowLong);
                SetCandleSettings(CandleSetting.DefaultShadowVeryLong);
                SetCandleSettings(CandleSetting.DefaultShadowShort);
                SetCandleSettings(CandleSetting.DefaultShadowVeryShort);
                SetCandleSettings(CandleSetting.DefaultNear);
                SetCandleSettings(CandleSetting.DefaultFar);
                SetCandleSettings(CandleSetting.DefaultEqual);
                return Success;
            
            default:
                {
                    CandleSetting candleSetting = CandleSetting.GetDefaultByType(settingType);
                    return SetCandleSettings(candleSetting);
                }
        }
    }
        
    public static RetCode SetCandleSettings(CandleSetting candleSetting)
    {
        if (candleSetting.SettingType >= AllCandleSettings)
        {
            return BadParam;
        }
        
        Globals.CandleSettings[candleSetting.SettingType] = candleSetting;
        
        return Success;
    }
}

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

public enum Compatibility
{
    Default,
    Metastock
}
        
public enum FuncUnstId
{
    FuncUnstNone = -1,
    Adx = 0,
    Adxr = 1,
    Atr = 2,
    Cmo = 3,
    Dx = 4,
    Ema = 5,
    HtDcPeriod = 6,
    HtDcPhase = 7,
    HtPhasor = 8,
    HtSine = 9,
    HtTrendline = 10,
    HtTrendMode = 11,
    Kama = 12,
    Mama = 13,
    Mfi = 14,
    MinusDI = 15,
    MinusDM = 16,
    Natr = 17,
    PlusDI = 18,
    PlusDM = 19,
    Rsi = 20,
    StochRsi = 21,
    T3 = 22,
    FuncUnstAll = 23
}
