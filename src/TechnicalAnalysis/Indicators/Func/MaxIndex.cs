using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.MaxIndex(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outInteger);
            
            return new MaxIndexResult(retCode, outBegIdx, outNBElement, outInteger);
        }
        
        public static MaxIndexResult MaxIndex(int startIdx, int endIdx, double[] real)
            => MaxIndex(startIdx, endIdx, real, 30);

        public static MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real, int timePeriod)
            => MaxIndex(startIdx, endIdx, real.ToDouble(), timePeriod);

        public static MaxIndexResult MaxIndex(int startIdx, int endIdx, float[] real)
            => MaxIndex(startIdx, endIdx, real, 30);
    }

    public record MaxIndexResult : IndicatorBase
    {
        public MaxIndexResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
