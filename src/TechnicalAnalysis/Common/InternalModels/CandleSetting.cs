namespace TechnicalAnalysis.Common;

internal sealed class CandleSetting
{
    public CandleSetting(
        CandleSettingType? settingType = null,
        RangeType? rangeType = null,
        int? avgPeriod = null,
        double? factor = null)
    {
        SettingType = settingType ?? default;
        RangeType = rangeType ?? default;
        AvgPeriod = avgPeriod ?? default;
        Factor = factor ?? default;
    }

    public CandleSettingType SettingType { get; }
    public RangeType RangeType { get; }
    public int AvgPeriod { get; }
    public double Factor { get; }
}
