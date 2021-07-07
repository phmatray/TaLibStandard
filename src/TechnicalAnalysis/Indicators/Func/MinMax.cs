using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MinMaxResult MinMax(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outMin = new double[endIdx - startIdx + 1];
            double[] outMax = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinMax(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outMin,
                ref outMax);
            
            return new MinMaxResult(retCode, outBegIdx, outNBElement, outMin, outMax);
        }

        public static MinMaxResult MinMax(int startIdx, int endIdx, double[] real)
            => MinMax(startIdx, endIdx, real, 30);

        public static MinMaxResult MinMax(int startIdx, int endIdx, float[] real, int timePeriod)
            => MinMax(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static MinMaxResult MinMax(int startIdx, int endIdx, float[] real)
            => MinMax(startIdx, endIdx, real, 30);
    }

    public record MinMaxResult : IndicatorBase
    {
        public MinMaxResult(RetCode retCode, int begIdx, int nbElement, double[] min, double[] max)
            : base(retCode, begIdx, nbElement)
        {
            Min = min;
            Max = max;
        }

        public double[] Max { get; }

        public double[] Min { get; }
    }
}
