using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static TanhResult Tanh(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Tanh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new TanhResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static TanhResult Tanh(int startIdx, int endIdx, float[] real)
            => Tanh(startIdx, endIdx, real.ToDouble());
    }
}
