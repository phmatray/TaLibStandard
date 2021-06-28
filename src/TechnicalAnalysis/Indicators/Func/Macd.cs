// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Macd.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines the TechnicalAnalysis type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Macd Macd(
            int startIdx,
            int endIdx,
            double[] real,
            int optInFastPeriod = 12,
            int optInSlowPeriod = 26,
            int optInSignalPeriod = 9)
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
                outMACD,
                outMACDSignal,
                outMACDHist);
            return new Macd(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
        }

        public static Macd Macd(
            int startIdx,
            int endIdx,
            float[] real,
            int optInFastPeriod = 12,
            int optInSlowPeriod = 26,
            int optInSignalPeriod = 9)
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
                outMACD,
                outMACDSignal,
                outMACDHist);
            return new Macd(retCode, outBegIdx, outNBElement, outMACD, outMACDSignal, outMACDHist);
        }
    }

    public class Macd : IndicatorBase
    {
        public Macd(
            RetCode retCode,
            int begIdx,
            int nbElement,
            double[] macdValue,
            double[] macdSignal,
            double[] macdHist)
            : base(retCode, begIdx, nbElement)
        {
            this.MacdValue = macdValue;
            this.MacdSignal = macdSignal;
            this.MacdHist = macdHist;
        }

        public double[] MacdValue { get; }

        public double[] MacdHist { get; }

        public double[] MacdSignal { get; }
    }
}