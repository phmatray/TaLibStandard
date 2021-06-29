// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AroonOsc.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines AroonOsc.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static AroonOsc AroonOsc(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.AroonOsc(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new AroonOsc(retCode, outBegIdx, outNBElement, outReal);
        }

        public static AroonOsc AroonOsc(int startIdx, int endIdx, double[] high, double[] low)
            => AroonOsc(startIdx, endIdx, high, low, 14);

        public static AroonOsc AroonOsc(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
            => AroonOsc(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

        public static AroonOsc AroonOsc(int startIdx, int endIdx, float[] high, float[] low)
            => AroonOsc(startIdx, endIdx, high, low, 14);
    }

    public class AroonOsc : IndicatorBase
    {
        public AroonOsc(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
