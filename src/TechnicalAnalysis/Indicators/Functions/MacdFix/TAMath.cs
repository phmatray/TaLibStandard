using TechnicalAnalysis.Common;
// ReSharper disable once CheckNamespace

namespace TechnicalAnalysis;

public static partial class TAMath
{
    public static MacdFixResult MacdFix(int startIdx, int endIdx, double[] real, int signalPeriod)
    {
        int outBegIdx = default;
        int outNBElement = default;
        double[] outMACD = new double[endIdx - startIdx + 1];
        double[] outMACDSignal = new double[endIdx - startIdx + 1];
        double[] outMACDHist = new double[endIdx - startIdx + 1];

        RetCode retCode = TACore.MacdFix(
            startIdx,
            endIdx,
            real,
            signalPeriod,
            ref outBegIdx,
            ref outNBElement,
            ref outMACD,
            ref outMACDSignal,
            ref outMACDHist);
            
        return new MacdFixResult(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
    }

    public static MacdFixResult MacdFix(int startIdx, int endIdx, double[] real)
        => MacdFix(startIdx, endIdx, real, 9);

    public static MacdFixResult MacdFix(int startIdx, int endIdx, float[] real, int signalPeriod)
        => MacdFix(startIdx, endIdx, real.ToDouble(), signalPeriod);
        
    public static MacdFixResult MacdFix(int startIdx, int endIdx, float[] real)
        => MacdFix(startIdx, endIdx, real, 9);
}
