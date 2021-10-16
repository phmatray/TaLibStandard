using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static StochFResult StochF(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int fastK_Period,
            int fastD_Period,
            MAType fastD_MAType)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outFastK = new double[endIdx - startIdx + 1];
            double[] outFastD = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.StochF(
                startIdx,
                endIdx,
                high,
                low,
                close,
                fastK_Period,
                fastD_Period,
                fastD_MAType,
                ref outBegIdx,
                ref outNBElement,
                ref outFastK,
                ref outFastD);
            
            return new(retCode, outBegIdx, outNBElement, outFastK, outFastD);
        }

        public static StochFResult StochF(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => StochF(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma);

        public static StochFResult StochF(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            int fastK_Period,
            int fastD_Period,
            MAType fastD_MAType)
            => StochF(
                startIdx,
                endIdx,
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                fastK_Period,
                fastD_Period,
                fastD_MAType);
        
        public static StochFResult StochF(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => StochF(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma);
    }
}
