// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdOsc.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines AdOsc.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static AdOsc AdOsc(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            double[] volume,
            int fastPeriod = 3,
            int slowPeriod = 10)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.AdOsc(
                startIdx,
                endIdx,
                high,
                low,
                close,
                volume,
                fastPeriod,
                slowPeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new AdOsc(retCode, outBegIdx, outNBElement, outReal);
        }

        public static AdOsc AdOsc(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            float[] volume,
            int fastPeriod = 3,
            int slowPeriod = 10)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.AdOsc(
                startIdx,
                endIdx,
                high,
                low,
                close,
                volume,
                fastPeriod,
                slowPeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new AdOsc(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class AdOsc : IndicatorBase
    {
        public AdOsc(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}