// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdOsc.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines AdOsc.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static AdOsc AdOsc(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            double[] volume,
            int fastPeriod,
            int slowPeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.AdOsc(
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
                ref outReal);
            
            return new AdOsc(retCode, outBegIdx, outNBElement, outReal);
        }
        
        public static AdOsc AdOsc(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            double[] volume)
            => AdOsc(startIdx, endIdx, high, low, close, volume, 3, 10);

        public static AdOsc AdOsc(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            float[] volume,
            int fastPeriod,
            int slowPeriod)
            => AdOsc(
                startIdx,
                endIdx,
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                volume.ToDouble(),
                fastPeriod,
                slowPeriod);
        
        public static AdOsc AdOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume)
            => AdOsc(startIdx, endIdx, high, low, close, volume, 3, 10);
    }

    public record AdOsc : IndicatorBase
    {
        public AdOsc(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
