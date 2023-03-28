// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.
namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents an enumeration of candlestick pattern settings.
/// </summary>
public enum CandleSettingType
{
    /// <summary>
    /// Long body setting.
    /// </summary>
    BodyLong,

    /// <summary>
    /// Very long body setting.
    /// </summary>
    BodyVeryLong,

    /// <summary>
    /// Short body setting.
    /// </summary>
    BodyShort,

    /// <summary>
    /// Doji body setting.
    /// </summary>
    BodyDoji,

    /// <summary>
    /// Long shadow setting.
    /// </summary>
    ShadowLong,

    /// <summary>
    /// Very long shadow setting.
    /// </summary>
    ShadowVeryLong,

    /// <summary>
    /// Short shadow setting.
    /// </summary>
    ShadowShort,

    /// <summary>
    /// Very short shadow setting.
    /// </summary>
    ShadowVeryShort,

    /// <summary>
    /// Near setting.
    /// </summary>
    Near,

    /// <summary>
    /// Far setting.
    /// </summary>
    Far,

    /// <summary>
    /// Equal setting.
    /// </summary>
    Equal,

    /// <summary>
    /// All candle settings.
    /// </summary>
    AllCandleSettings
}
