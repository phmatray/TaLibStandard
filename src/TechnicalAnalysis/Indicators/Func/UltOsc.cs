// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UltOsc.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines UltOsc.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static UltOsc UltOsc(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int timePeriod1 = 7,
            int timePeriod2 = 14,
            int timePeriod3 = 28)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.UltOsc(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod1,
                timePeriod2,
                timePeriod3,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new UltOsc(retCode, outBegIdx, outNBElement, outReal);
        }

        public static UltOsc UltOsc(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            int timePeriod1 = 7,
            int timePeriod2 = 14,
            int timePeriod3 = 28)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.UltOsc(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod1,
                timePeriod2,
                timePeriod3,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new UltOsc(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class UltOsc : IndicatorBase
    {
        public UltOsc(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
