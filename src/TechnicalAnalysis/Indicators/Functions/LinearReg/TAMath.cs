using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static LinearRegResult LinearReg(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.LinearReg(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new LinearRegResult(retCode, outBegIdx, outNBElement, outReal);
        }
        
        public static LinearRegResult LinearReg(int startIdx, int endIdx, double[] real)
            => LinearReg(startIdx, endIdx, real, 14);

        public static LinearRegResult LinearReg(int startIdx, int endIdx, float[] real, int timePeriod)
            => LinearReg(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static LinearRegResult LinearReg(int startIdx, int endIdx, float[] real)
            => LinearReg(startIdx, endIdx, real, 14);
    }
}
