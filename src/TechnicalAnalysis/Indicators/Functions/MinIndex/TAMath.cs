using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MinIndexResult MinIndex(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinIndex(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outInteger);
            
            return new(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static MinIndexResult MinIndex(int startIdx, int endIdx, double[] real)
            => MinIndex(startIdx, endIdx, real, 30);

        public static MinIndexResult MinIndex(int startIdx, int endIdx, float[] real, int timePeriod)
            => MinIndex(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static MinIndexResult MinIndex(int startIdx, int endIdx, float[] real)
            => MinIndex(startIdx, endIdx, real, 30);
    }
}
