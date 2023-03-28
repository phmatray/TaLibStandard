namespace TechnicalAnalysis.Business;

public class DataHistory
{
    public DataHistory(List<Candle> candles)
    {
        if (candles == null)
        {
            throw new ArgumentNullException(nameof(candles));
        }

        if (candles.Count == 0)
        {
            throw new ArgumentException("Value cannot be an empty collection.", nameof(candles));
        }

        Count = candles.Count;
        Open = candles.Select(x => x.Open).ToArray();
        High = candles.Select(x => x.High).ToArray();
        Low = candles.Select(x => x.Low).ToArray();
        Close = candles.Select(x => x.Close).ToArray();
        Volume = candles.Select(x => x.Volumefrom).ToArray();

        Average = candles
            .Select(x => (x.Open + x.High + x.Low + x.Close) / 4)
            .ToArray();

        Indicators = new Dictionary<Indicator, IndicatorBase>();
    }

    public int Count { get; }

    public double[] Open { get; }

    public double[] High { get; }

    public double[] Low { get; }

    public double[] Close { get; }

    public double[] Volume { get; }

    public double[] Average { get; }

    public Dictionary<Indicator, IndicatorBase> Indicators { get; }
}