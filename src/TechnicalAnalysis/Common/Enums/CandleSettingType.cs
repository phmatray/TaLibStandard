namespace TechnicalAnalysis.Common;

/// <summary>
/// The <see cref="CandleSettingType"/> enum specifies which kind of setting to consider;
/// the settings are based on the parts of the candle and the common words
/// indicating the length (short, long, very long).
/// </summary>
public enum CandleSettingType
{
    BodyLong = 0,
    BodyVeryLong = 1,
    BodyShort = 2,
    BodyDoji = 3,
    ShadowLong = 4,
    ShadowVeryLong = 5,
    ShadowShort = 6,
    ShadowVeryShort = 7,
    Near = 8,
    Far = 9,
    Equal = 10,
    AllCandleSettings = 11
}
