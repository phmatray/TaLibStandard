using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static LinearRegAngleResult LinearRegAngle(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.LinearRegAngle(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new LinearRegAngleResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static LinearRegAngleResult LinearRegAngle(int startIdx, int endIdx, double[] real)
            => LinearRegAngle(startIdx, endIdx, real, 14);

        public static LinearRegAngleResult LinearRegAngle(int startIdx, int endIdx, float[] real, int timePeriod)
            => LinearRegAngle(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static LinearRegAngleResult LinearRegAngle(int startIdx, int endIdx, float[] real)
            => LinearRegAngle(startIdx, endIdx, real, 14);
    }

    public record LinearRegAngleResult : IndicatorBase
    {
        public LinearRegAngleResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
