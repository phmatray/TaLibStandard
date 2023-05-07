// Copyright (c) 2023 Philippe Matray. All rights reserved.
// This file is part of TaLibStandard.
// TaLibStandard is licensed under the GNU General Public License v3.0.
// See the LICENSE file in the project root for the full license text.
// For more information, visit https://github.com/phmatray/TaLibStandard.

namespace TechnicalAnalysis.Common;

public sealed class GlobalsType
{
    public Dictionary<FuncUnstId, long> UnstablePeriod { get; }
    public Dictionary<CandleSettingType, CandleSetting> CandleSettings { get; }
    public Compatibility Compatibility { get; set; } = Compatibility.Default;

    public GlobalsType()
    {
        UnstablePeriod = Enumerable
            .Range(0, 23)
            .ToDictionary(i => (FuncUnstId)i, _ => 0L);
        
        CandleSettings = new Dictionary<CandleSettingType, CandleSetting>
        {
            { BodyLong, CandleSetting.DefaultBodyLong },
            { BodyVeryLong, CandleSetting.DefaultBodyVeryLong },
            { BodyShort, CandleSetting.DefaultBodyShort },
            { BodyDoji, CandleSetting.DefaultBodyDoji },
            { ShadowLong, CandleSetting.DefaultShadowLong },
            { ShadowVeryLong, CandleSetting.DefaultShadowVeryLong },
            { ShadowShort, CandleSetting.DefaultShadowShort },
            { ShadowVeryShort, CandleSetting.DefaultShadowVeryShort },
            { Near, CandleSetting.DefaultNear },
            { Far, CandleSetting.DefaultFar },
            { Equal, CandleSetting.DefaultEqual }
        };
    }
}
