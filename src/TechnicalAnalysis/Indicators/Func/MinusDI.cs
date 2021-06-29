// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinusDI.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MinusDI.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MinusDI MinusDI(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinusDI(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new MinusDI(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MinusDI MinusDI(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => MinusDI(startIdx, endIdx, high, low, close, 14);

        public static MinusDI MinusDI(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            int timePeriod)
            => MinusDI(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

        public static MinusDI MinusDI(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => MinusDI(startIdx, endIdx, high, low, close, 14);
    }

    public class MinusDI : IndicatorBase
    {
        public MinusDI(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
