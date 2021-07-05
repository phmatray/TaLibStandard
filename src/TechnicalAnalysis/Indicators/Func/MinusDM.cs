// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinusDM.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MinusDM.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MinusDM MinusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinusDM(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new MinusDM(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MinusDM MinusDM(int startIdx, int endIdx, double[] high, double[] low)
            => MinusDM(startIdx, endIdx, high, low, 14);

        public static MinusDM MinusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
            => MinusDM(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

        public static MinusDM MinusDM(int startIdx, int endIdx, float[] high, float[] low)
            => MinusDM(startIdx, endIdx, high, low, 14);
    }

    public class MinusDM : IndicatorBase
    {
        public MinusDM(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
