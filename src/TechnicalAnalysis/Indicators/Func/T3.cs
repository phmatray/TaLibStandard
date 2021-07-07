using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static T3Result T3(int startIdx, int endIdx, double[] real, int timePeriod, double vFactor)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.T3(
                startIdx,
                endIdx,
                real,
                timePeriod,
                vFactor,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new T3Result(retCode, outBegIdx, outNBElement, outReal);
        }

        public static T3Result T3(int startIdx, int endIdx, double[] real)
            => T3(startIdx, endIdx, real, 5, 0.7);

        public static T3Result T3(int startIdx, int endIdx, float[] real, int timePeriod, double vFactor)
            => T3(startIdx, endIdx, real.ToDouble(), timePeriod, vFactor);
        
        public static T3Result T3(int startIdx, int endIdx, float[] real)
            => T3(startIdx, endIdx, real, 5, 0.7);
    }

    public record T3Result : IndicatorBase
    {
        public T3Result(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
