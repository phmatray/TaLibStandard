
using System;

namespace TechnicalAnalysis.Abstractions
{
    public abstract class CandleIndicator
    {
        protected double[] open;
        protected double[] high;
        protected double[] low;
        protected double[] close;

        protected CandleIndicator(double[] open, double[] high, double[] low, double[] close)
        {
            this.open = open;
            this.high = high;
            this.low = low;
            this.close = close;
        }

        public RangeType GetCandleRangeType(CandleSettingType candleSettingType)
            => TACore.Globals.candleSettings[(int)candleSettingType].rangeType;
        
        public int GetCandleAvgPeriod(CandleSettingType candleSettingType)
            => TACore.Globals.candleSettings[(int)candleSettingType].avgPeriod;
        
        public double GetCandleFactor(CandleSettingType candleSettingType)
            => TACore.Globals.candleSettings[(int)candleSettingType].factor;
        
        public double GetCandleRange(
            CandleSettingType candleSettingType,
            int index,
            in double[] open,
            in double[] high,
            in double[] low,
            in double[] close)
        {
            return GetCandleRangeType(candleSettingType) switch
            {
                RangeType.RealBody => GetRealBody(index, open, close),
                RangeType.HighLow => GetHighLowRange(index, high, low),
                RangeType.Shadows => GetUpperShadow(index, open, high, close) + GetLowerShadow(index, open, low, close),
                _ => 0.0
            };
        }

        public double GetCandleAverage(
            CandleSettingType candleSettingType,
            double sum,
            int index,
            in double[] open,
            in double[] high,
            in double[] low,
            in double[] close)
        {
            return GetCandleFactor(candleSettingType)
                   * (GetCandleAvgPeriod(candleSettingType) != 0.0
                       ? sum / GetCandleAvgPeriod(candleSettingType)
                       : GetCandleRange(candleSettingType, index, open, high, low, close))
                   / (GetCandleRangeType(candleSettingType) == RangeType.Shadows ? 2.0 : 1.0);
        }

        public double GetRealBody(int index, in double[] open, in double[] close)
            => Math.Abs(close[index] - open[index]);

        public double GetUpperShadow(int index, in double[] open, in double[] high, in double[] close)
            => high[index] - (close[index] >= open[index] ? close[index] : open[index]);

        public double GetLowerShadow(int index, in double[] open, in double[] low, in double[] close)
            => (close[index] >= open[index] ? open[index] : close[index]) - low[index];

        public double GetHighLowRange(int index, in double[] high, in double[] low)
            => high[index] - low[index];

        public int GetCandleColor(int index, in double[] open, in double[] close)
            => close[index] >= open[index] ? 1 : -1;

        public bool GetRealBodyGapUp(int index2, int index1, in double[] open, in double[] close)
            => Math.Min(open[index2], close[index2]) > Math.Max(open[index1], close[index1]);

        public bool GetRealBodyGapDown(int index2, int index1, in double[] open, in double[] close)
            => Math.Max(open[index2], close[index2]) < Math.Min(open[index1], close[index1]);

        public bool GetCandleGapUp(int index2, int index1, in double[] high, in double[] low)
            => low[index2] > high[index1];

        public bool GetCandleGapDown(int index2, int index1, in double[] high, in double[] low)
            => high[index2] < low[index1];
    }
}
