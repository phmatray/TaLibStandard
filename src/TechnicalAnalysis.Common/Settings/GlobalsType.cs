// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

using static TechnicalAnalysis.Common.CandleSetting;

namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents the global settings for the Technical Analysis library.
/// </summary>
public sealed class GlobalsType
{
    /// <summary>
    /// Gets the unstable periods for all functions.
    /// </summary>
    public Dictionary<FuncUnstId, long> UnstablePeriod { get; }
    
    /// <summary>
    /// Gets the candle settings for all candle setting types.
    /// </summary>
    public Dictionary<CandleSettingType, CandleSetting> CandleSettings { get; }
    
    /// <summary>
    /// Gets or sets the compatibility mode of the Technical Analysis library.
    /// </summary>
    public Compatibility Compatibility { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalsType"/> class with default settings.
    /// </summary>
    public GlobalsType()
    {
        UnstablePeriod = InitializeUnstablePeriods();
        CandleSettings = InitializeCandleSettings();
        Compatibility = Compatibility.Default;
    }

    private static Dictionary<FuncUnstId, long> InitializeUnstablePeriods()
        => Enumerable
            .Range(0, 23)
            .ToDictionary(i => (FuncUnstId)i, _ => 0L);

    private static Dictionary<CandleSettingType, CandleSetting> InitializeCandleSettings()
        => new()
        {
            { BodyLong,        DefaultBodyLong },
            { BodyVeryLong,    DefaultBodyVeryLong },
            { BodyShort,       DefaultBodyShort },
            { BodyDoji,        DefaultBodyDoji },
            { ShadowLong,      DefaultShadowLong },
            { ShadowVeryLong,  DefaultShadowVeryLong },
            { ShadowShort,     DefaultShadowShort },
            { ShadowVeryShort, DefaultShadowVeryShort },
            { Near,            DefaultNear },
            { Far,             DefaultFar },
            { Equal,           DefaultEqual }
        };
}
