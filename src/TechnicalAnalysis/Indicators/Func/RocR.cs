using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static RocRResult RocR(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.RocR(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new RocRResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static RocRResult RocR(int startIdx, int endIdx, double[] real)
            => RocR(startIdx, endIdx, real, 10);

        public static RocRResult RocR(int startIdx, int endIdx, float[] real, int timePeriod)
            => RocR(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static RocRResult RocR(int startIdx, int endIdx, float[] real)
            => RocR(startIdx, endIdx, real, 10);
    }

    public record RocRResult : IndicatorBase
    {
        public RocRResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
