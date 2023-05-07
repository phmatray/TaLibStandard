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
        return id >= FuncUnstId.FuncUnstAll ? 0 : Globals.UnstablePeriod[id];
    }
        
    public static RetCode SetUnstablePeriod(FuncUnstId id, long unstablePeriod)
    {
        switch (id)
        {
            case > FuncUnstId.FuncUnstAll:
                return BadParam;
            case FuncUnstId.FuncUnstAll:
                {
                    for (int i = 0; i < 23; i++)
                    {
                        Globals.UnstablePeriod[(FuncUnstId)i] = unstablePeriod;
                    }

                    return Success;
                }
            default:
                Globals.UnstablePeriod[id] = unstablePeriod;
                return Success;
        }
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
