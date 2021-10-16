using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
       public static StochResult Stoch(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int fastK_Period,
            int slowK_Period,
            MAType slowK_MAType,
            int slowD_Period,
            MAType slowD_MAType)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outSlowK = new double[endIdx - startIdx + 1];
            double[] outSlowD = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Stoch(
                startIdx,
                endIdx,
                high,
                low,
                close,
                fastK_Period,
                slowK_Period,
                slowK_MAType,
                slowD_Period,
                slowD_MAType,
                ref outBegIdx,
                ref outNBElement,
                ref outSlowK,
                ref outSlowD);
            
            return new(retCode, outBegIdx, outNBElement, outSlowK, outSlowD);
        }

       public static StochResult Stoch(int startIdx, int endIdx, double[] high, double[] low, double[] close)
           => Stoch(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma, 3, MAType.Sma);

        public static StochResult Stoch(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            int fastK_Period,
            int slowK_Period,
            MAType slowK_MAType,
            int slowD_Period,
            MAType slowD_MAType)
            => Stoch(
                startIdx,
                endIdx,
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                fastK_Period,
                slowK_Period,
                slowK_MAType,
                slowD_Period,
                slowD_MAType);
        
        public static StochResult Stoch(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => Stoch(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma, 3, MAType.Sma);
    }
}
