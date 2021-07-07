using static System.Math;

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

        public abstract int GetLookback();
        public abstract bool GetPatternRecognition(int i);

        protected RangeType GetCandleRangeType(CandleSettingType candleSettingType)
            => TACore.Globals.candleSettings[(int)candleSettingType].rangeType;
        
        protected int GetCandleAvgPeriod(CandleSettingType candleSettingType)
            => TACore.Globals.candleSettings[(int)candleSettingType].avgPeriod;
        
        protected double GetCandleFactor(CandleSettingType candleSettingType)
            => TACore.Globals.candleSettings[(int)candleSettingType].factor;
        
        protected double GetCandleRange(CandleSettingType candleSettingType, int index)
        {
            return GetCandleRangeType(candleSettingType) switch
            {
                RangeType.RealBody => GetRealBody(index),
                RangeType.HighLow => GetHighLowRange(index),
                RangeType.Shadows => GetUpperShadow(index) + GetLowerShadow(index),
                _ => 0.0
            };
        }

        protected double GetCandleAverage(CandleSettingType candleSettingType, double sum, int index)
        {
            return GetCandleFactor(candleSettingType)
                   * (GetCandleAvgPeriod(candleSettingType) != 0.0
                       ? sum / GetCandleAvgPeriod(candleSettingType)
                       : GetCandleRange(candleSettingType, index))
                   / (GetCandleRangeType(candleSettingType) == RangeType.Shadows ? 2.0 : 1.0);
        }

        protected double GetRealBody(int index)
            => Abs(close[index] - open[index]);

        protected double GetUpperShadow(int index)
            => high[index] - (close[index] >= open[index] ? close[index] : open[index]);

        protected double GetLowerShadow(int index)
            => (close[index] >= open[index] ? open[index] : close[index]) - low[index];

        protected double GetHighLowRange(int index)
            => high[index] - low[index];

        protected int GetCandleColor(int index)
            => close[index] >= open[index] ? 1 : -1;

        protected bool GetRealBodyGapUp(int index2, int index1)
            => Min(open[index2], close[index2]) > Max(open[index1], close[index1]);

        protected bool GetRealBodyGapDown(int index2, int index1)
            => Max(open[index2], close[index2]) < Min(open[index1], close[index1]);

        protected bool GetCandleGapUp(int index2, int index1)
            => low[index2] > high[index1];

        protected bool GetCandleGapDown(int index2, int index1)
            => high[index2] < low[index1];
    }
}
