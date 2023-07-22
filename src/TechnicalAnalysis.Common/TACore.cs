// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

/// <summary>
/// 
/// </summary>
public static partial class TACore
{
    /// <summary>
    /// 
    /// </summary>
    public static GlobalsType Globals { get; }

    static TACore()
    {
        Globals = new GlobalsType();
    }
        
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static Compatibility GetCompatibility()
    {
        return Globals.Compatibility;
    }
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static RetCode SetCompatibility(Compatibility value)
    {
        Globals.Compatibility = value;
        return Success;
    }
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static long GetUnstablePeriod(FuncUnstId id)
    {
        return id >= FuncUnstId.FuncUnstAll ? 0 : Globals.UnstablePeriod[id];
    }
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="unstablePeriod"></param>
    /// <returns></returns>
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
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="settingType"></param>
    /// <returns></returns>
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
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="candleSetting"></param>
    /// <returns></returns>
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
