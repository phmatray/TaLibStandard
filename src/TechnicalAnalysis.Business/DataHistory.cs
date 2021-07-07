using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis.Business
{
    public class DataHistory
    {
        private readonly List<Candle> candles;

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

            this.candles = candles;

            this.Count = candles.Count;
            this.Open = candles.Select(x => x.Open).ToArray();
            this.High = candles.Select(x => x.High).ToArray();
            this.Low = candles.Select(x => x.Low).ToArray();
            this.Close = candles.Select(x => x.Close).ToArray();
            this.Volume = candles.Select(x => x.Volumefrom).ToArray();

            this.Average = candles
                .Select(x => (x.Open + x.High + x.Low + x.Close) / 4)
                .ToArray();

            this.Indicators = new Dictionary<Indicator, IndicatorBase>();
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
}
