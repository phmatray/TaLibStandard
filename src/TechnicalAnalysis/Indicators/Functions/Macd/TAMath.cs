using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MacdResult Macd(
            int startIdx,
            int endIdx,
            double[] real,
            int optInFastPeriod,
            int optInSlowPeriod,
            int optInSignalPeriod)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outMACD = new double[endIdx - startIdx + 1];
            double[] outMACDSignal = new double[endIdx - startIdx + 1];
            double[] outMACDHist = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Macd(
                startIdx,
                endIdx,
                real,
                optInFastPeriod,
                optInSlowPeriod,
                optInSignalPeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outMACD,
                ref outMACDSignal,
                ref outMACDHist);
            
            return new(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
        }

        public static MacdResult Macd(int startIdx, int endIdx, double[] real)
            => Macd(startIdx, endIdx, real, 12, 26, 9);

        public static MacdResult Macd(
            int startIdx,
            int endIdx,
            float[] real,
            int optInFastPeriod,
            int optInSlowPeriod,
            int optInSignalPeriod)
            => Macd(startIdx, endIdx, real.ToDouble(), optInFastPeriod, optInSlowPeriod, optInSignalPeriod);
        
        public static MacdResult Macd(int startIdx, int endIdx, float[] real)
            => Macd(startIdx, endIdx, real, 12, 26, 9);
    }
}
