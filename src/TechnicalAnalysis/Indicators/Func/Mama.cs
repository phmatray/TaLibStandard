using TechnicalAnalysis.Common;

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
            
            return new MamaResult(retCode, outBegIdx, outNBElement, outMAMA, outFAMA);
        }
        
        public static MamaResult Mama(int startIdx, int endIdx, double[] real)
            => Mama(startIdx, endIdx, real, 0.5, 0.05);

        public static MamaResult Mama(int startIdx, int endIdx, float[] real, double fastLimit, double slowLimit)
            => Mama(startIdx, endIdx, real.ToDouble(), fastLimit, slowLimit);
        
        public static MamaResult Mama(int startIdx, int endIdx, float[] real)
            => Mama(startIdx, endIdx, real, 0.5, 0.05);
    }

    public record MamaResult : IndicatorBase
    {
        public MamaResult(RetCode retCode, int begIdx, int nbElement, double[] mama, double[] fama)
            : base(retCode, begIdx, nbElement)
        {
            MAMA = mama;
            FAMA = fama;
        }

        public double[] FAMA { get; }

        public double[] MAMA { get; }
    }
}
