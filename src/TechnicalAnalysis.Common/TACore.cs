// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis;

/// <summary>
/// Provides core functionalities for the Technical Analysis library.
/// </summary>
public static partial class TACore
{
    /// <summary>
    /// Gets the global settings for the Technical Analysis library.
    /// </summary>
    public static GlobalsType Globals { get; }

    static TACore()
    {
        Globals = new GlobalsType();
    }
        
    /// <summary>
    /// Gets the compatibility mode of the Technical Analysis library.
    /// </summary>
    /// <returns>The current compatibility mode.</returns>
    public static Compatibility GetCompatibility()
    {
        return Globals.Compatibility;
    }
        
    /// <summary>
    /// Sets the compatibility mode of the Technical Analysis library.
    /// </summary>
    /// <param name="value">The compatibility mode to set.</param>
    /// <returns>A return code indicating the result of the operation.</returns>
    public static RetCode SetCompatibility(Compatibility value)
    {
        Globals.Compatibility = value;
        return Success;
    }
        
    /// <summary>
    /// Gets the unstable period for a given function.
    /// </summary>
    /// <param name="id">The identifier of the function.</param>
    /// <returns>The unstable period for the function.</returns>
    public static long GetUnstablePeriod(FuncUnstId id)
    {
        return id >= FuncUnstId.FuncUnstAll ? 0 : Globals.UnstablePeriod[id];
    }
        
    /// <summary>
    /// Sets the unstable period for a given function.
    /// </summary>
    /// <param name="id">The identifier of the function.</param>
    /// <param name="unstablePeriod">The unstable period to set.</param>
    /// <returns>A return code indicating the result of the operation.</returns>
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
    /// Restores the default settings for a given candle setting type.
    /// </summary>
    /// <param name="settingType">The type of the candle setting.</param>
    /// <returns>A return code indicating the result of the operation.</returns>
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
    /// Sets the candle settings for a given candle setting type.
    /// </summary>
    /// <param name="candleSetting">The candle setting to set.</param>
    /// <returns>A return code indicating the result of the operation.</returns>
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
