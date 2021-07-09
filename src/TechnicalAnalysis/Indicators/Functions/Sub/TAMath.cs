using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static SubResult Sub(int startIdx, int endIdx, double[] real0, double[] real1)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sub(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new SubResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SubResult Sub(int startIdx, int endIdx, float[] real0, float[] real1)
            => Sub(startIdx, endIdx, real0.ToDouble(), real1.ToDouble());
    }
}
