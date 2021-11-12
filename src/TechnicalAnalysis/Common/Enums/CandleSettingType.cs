namespace TechnicalAnalysis.Common;

/// <summary>
/// The TA_CandleSettingType enum specifies which kind of setting to consider;
/// the settings are based on the parts of the candle and the common words
/// indicating the length (short, long, very long).
/// </summary>
public enum CandleSettingType
{
    BodyLong,
    BodyVeryLong,
    BodyShort,
    BodyDoji,
    ShadowLong,
    ShadowVeryLong,
    ShadowShort,
    ShadowVeryShort,
    Near,
    Far,
    Equal,
    AllCandleSettings
}
