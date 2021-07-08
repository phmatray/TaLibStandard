using System.Linq;
using static System.Math;

namespace TechnicalAnalysis.Common
{
    public abstract class CandleIndicator
    {
        protected double[] _open;
        protected double[] _high;
        protected double[] _low;
        protected double[] _close;

        protected CandleIndicator(double[] open, double[] high, double[] low, double[] close)
        {
            _open = open;
            _high = high;
            _low = low;
            _close = close;
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
            => Abs(_close[index] - _open[index]);

        protected double GetUpperShadow(int index)
            => _high[index] - (_close[index] >= _open[index] ? _close[index] : _open[index]);

        protected double GetLowerShadow(int index)
            => (_close[index] >= _open[index] ? _open[index] : _close[index]) - _low[index];

        protected double GetHighLowRange(int index)
            => _high[index] - _low[index];

        protected int GetCandleColor(int index)
            => _close[index] >= _open[index] ? 1 : -1;

        protected bool GetRealBodyGapUp(int index2, int index1)
            => Min(_open[index2], _close[index2]) > Max(_open[index1], _close[index1]);

        protected bool GetRealBodyGapDown(int index2, int index1)
            => Max(_open[index2], _close[index2]) < Min(_open[index1], _close[index1]);

        protected bool GetCandleGapUp(int index2, int index1)
            => _low[index2] > _high[index1];

        protected bool GetCandleGapDown(int index2, int index1)
            => _high[index2] < _low[index1];

        protected int GetCandleMaxAvgPeriod(params CandleSettingType[] candleSettingTypes)
            => candleSettingTypes
                .Select(GetCandleAvgPeriod)
                .Aggregate(Max);
    }
}
