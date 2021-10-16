using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static AcosResult Acos(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Acos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new(retCode, outBegIdx, outNBElement, outReal);
        }

        public static AcosResult Acos(int startIdx, int endIdx, float[] real)
            => Acos(startIdx, endIdx, real.ToDouble());
    }
}
