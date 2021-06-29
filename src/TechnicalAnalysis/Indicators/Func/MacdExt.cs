// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MacdExt.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MacdExt.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MacdExt MacdExt(
            int startIdx,
            int endIdx,
            double[] real,
            int fastPeriod,
            MAType fastMAType,
            int slowPeriod,
            MAType slowMAType,
            int signalPeriod,
            MAType signalMAType)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outMACD = new double[endIdx - startIdx + 1];
            double[] outMACDSignal = new double[endIdx - startIdx + 1];
            double[] outMACDHist = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MacdExt(
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
        
        public static MacdExt MacdExt(int startIdx, int endIdx, double[] real)
            => MacdExt(startIdx, endIdx, real, 12, MAType.Sma, 26, MAType.Sma, 9, MAType.Sma);

        public static MacdExt MacdExt(
            int startIdx,
            int endIdx,
            float[] real,
            int fastPeriod,
            MAType fastMAType,
            int slowPeriod,
            MAType slowMAType,
            int signalPeriod,
            MAType signalMAType)
            => MacdExt(
                startIdx,
                endIdx,
                real.ToDouble(),
                fastPeriod,
                fastMAType,
                slowPeriod,
                slowMAType,
                signalPeriod,
                signalMAType);
        
        public static MacdExt MacdExt(int startIdx, int endIdx, float[] real)
            => MacdExt(startIdx, endIdx, real, 12, MAType.Sma, 26, MAType.Sma, 9, MAType.Sma);
    }

    public class MacdExt : IndicatorBase
    {
        public MacdExt(
            RetCode retCode,
            int begIdx,
            int nbElement,
            double[] macd,
            double[] macdSignal,
            double[] macdHist)
            : base(retCode, begIdx, nbElement)
        {
            this.MACD = macd;
            this.MACDSignal = macdSignal;
            this.MACDHist = macdHist;
        }

        public double[] MACD { get; }

        public double[] MACDHist { get; }

        public double[] MACDSignal { get; }
    }
}
