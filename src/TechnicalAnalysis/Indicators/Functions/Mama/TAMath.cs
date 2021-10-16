using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MamaResult Mama(int startIdx, int endIdx, double[] real, double fastLimit, double slowLimit)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outMAMA = new double[endIdx - startIdx + 1];
            double[] outFAMA = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Mama(
                startIdx,
                endIdx,
                real,
                fastLimit,
                slowLimit,
                ref outBegIdx,
                ref outNBElement,
                ref outMAMA,
                ref outFAMA);
            
            return new(retCode, outBegIdx, outNBElement, outMAMA, outFAMA);
        }
        
        public static MamaResult Mama(int startIdx, int endIdx, double[] real)
            => Mama(startIdx, endIdx, real, 0.5, 0.05);

        public static MamaResult Mama(int startIdx, int endIdx, float[] real, double fastLimit, double slowLimit)
            => Mama(startIdx, endIdx, real.ToDouble(), fastLimit, slowLimit);
        
        public static MamaResult Mama(int startIdx, int endIdx, float[] real)
            => Mama(startIdx, endIdx, real, 0.5, 0.05);
    }
}
