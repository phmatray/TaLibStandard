using System;

namespace TechnicalAnalysis
{
    internal static partial class TACore
    {
        public static RangeType GetCandleRangeType(CandleSettingType candleSettingType)
            => Globals.candleSettings[(int)candleSettingType].rangeType;
        
        public static int GetCandleAvgPeriod(CandleSettingType candleSettingType)
            => Globals.candleSettings[(int)candleSettingType].avgPeriod;
        
        public static double GetCandleFactor(CandleSettingType candleSettingType)
            => Globals.candleSettings[(int)candleSettingType].factor;

        public static double GetCandleRange(
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

        public static double GetCandleAverage(
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

        public static double GetRealBody(int index, in double[] open, in double[] close)
            => Math.Abs(close[index] - open[index]);

        public static double GetUpperShadow(int index, in double[] open, in double[] high, in double[] close)
            => high[index] - (close[index] >= open[index] ? close[index] : open[index]);

        public static double GetLowerShadow(int index, in double[] open, in double[] low, in double[] close)
            => (close[index] >= open[index] ? open[index] : close[index]) - low[index];

        public static double GetHighLowRange(int index, in double[] high, in double[] low)
            => high[index] - low[index];

        public static int GetCandleColor(int index, in double[] open, in double[] close)
            => close[index] >= open[index] ? 1 : -1;
    }
}
