// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MacdExt.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MacdExt.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MacdExt MacdExt(
            int startIdx,
            int endIdx,
            double[] real,
            int fastPeriod = 12,
            MAType fastMAType = MAType.Sma,
            int slowPeriod = 26,
            MAType slowMAType = MAType.Sma,
            int signalPeriod = 9,
            MAType signalMAType = MAType.Sma)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outMACD = new double[endIdx - startIdx + 1];
            double[] outMACDSignal = new double[endIdx - startIdx + 1];
            double[] outMACDHist = new double[endIdx - startIdx + 1];

            var retCode = TACore.MacdExt(
                startIdx,
                endIdx,
                real,
                fastPeriod,
                fastMAType,
                slowPeriod,
                slowMAType,
                signalPeriod,
                signalMAType,
                ref outBegIdx,
                ref outNBElement,
                outMACD,
                outMACDSignal,
                outMACDHist);
            return new MacdExt(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
        }

        public static MacdExt MacdExt(
            int startIdx,
            int endIdx,
            float[] real,
            int fastPeriod = 12,
            MAType fastMAType = MAType.Sma,
            int slowPeriod = 26,
            MAType slowMAType = MAType.Sma,
            int signalPeriod = 9,
            MAType signalMAType = MAType.Sma)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outMACD = new double[endIdx - startIdx + 1];
            double[] outMACDSignal = new double[endIdx - startIdx + 1];
            double[] outMACDHist = new double[endIdx - startIdx + 1];

            var retCode = TACore.MacdExt(
                startIdx,
                endIdx,
                real,
                fastPeriod,
                fastMAType,
                slowPeriod,
                slowMAType,
                signalPeriod,
                signalMAType,
                ref outBegIdx,
                ref outNBElement,
                outMACD,
                outMACDSignal,
                outMACDHist);
            return new MacdExt(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
        }
    }

    public class MacdExt : IndicatorBase
    {
        public MacdExt(
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