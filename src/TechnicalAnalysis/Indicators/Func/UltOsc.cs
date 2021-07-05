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
    public static partial class TAMath
    {
        public static UltOsc UltOsc(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int timePeriod1,
            int timePeriod2,
            int timePeriod3)
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
                ref outReal);
            
            return new UltOsc(retCode, outBegIdx, outNBElement, outReal);
        }

        public static UltOsc UltOsc(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => UltOsc(startIdx, endIdx, high, low, close, 7, 14, 28);

        public static UltOsc UltOsc(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            int timePeriod1,
            int timePeriod2,
            int timePeriod3)
            => UltOsc(
                startIdx,
                endIdx,
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                timePeriod1,
                timePeriod2,
                timePeriod3);
        
        public static UltOsc UltOsc(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => UltOsc(startIdx, endIdx, high, low, close, 7, 14, 28);
    }

    public class UltOsc : IndicatorBase
    {
        public UltOsc(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
