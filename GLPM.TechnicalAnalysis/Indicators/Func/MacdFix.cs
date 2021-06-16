// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MacdFix.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MacdFix.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MacdFix MacdFix(int startIdx, int endIdx, double[] real, int signalPeriod = 9)
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
                outMACD,
                outMACDSignal,
                outMACDHist);
            return new MacdFix(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
        }

        public static MacdFix MacdFix(int startIdx, int endIdx, float[] real, int signalPeriod = 9)
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
                outMACD,
                outMACDSignal,
                outMACDHist);
            return new MacdFix(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
        }
    }

    public class MacdFix : IndicatorBase
    {
        public MacdFix(
            RetCode retCode,
            int begIdx,
            int nbElement,
            double[] mACD,
            double[] mACDSignal,
            double[] mACDHist)
            : base(retCode, begIdx, nbElement)
        {
            this.MACD = mACD;
            this.MACDSignal = mACDSignal;
            this.MACDHist = mACDHist;
        }

        public double[] MACD { get; }

        public double[] MACDHist { get; }

        public double[] MACDSignal { get; }
    }
}