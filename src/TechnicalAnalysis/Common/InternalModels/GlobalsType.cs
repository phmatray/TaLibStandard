namespace TechnicalAnalysis.Common;

internal sealed class GlobalsType
{
    /// <summary>
    /// For handling the compatibility with other software
    /// </summary>
    public Compatibility Compatibility { get; set; }

    /// <summary>
    /// For handling the unstable period of some TA function.
    /// </summary>
    public Dictionary<FuncUnstId, long> UnstablePeriods { get; }

    /// <summary>
    /// For handling the candlestick global settings
    /// </summary>
    public Dictionary<CandleSettingType, CandleSetting> CandleSettings { get; }

    public GlobalsType()
    {
        Compatibility = Compatibility.Default;

        UnstablePeriods = new Dictionary<FuncUnstId, long>();
        for (int i = 0; i < (int)FuncUnstId.FuncUnstAll; i++)
        {
            UnstablePeriods[(FuncUnstId)i] = 0;
        }

        CandleSettings = new Dictionary<CandleSettingType, CandleSetting>();
        for (int i = 0; i < (int)CandleSettingType.AllCandleSettings; i++)
        {
            CandleSettings[(CandleSettingType)i] = new CandleSetting();
        }
    }
}
