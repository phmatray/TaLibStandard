// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinusDM.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MinusDM.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MinusDM MinusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod = 14)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.MinusDM(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new MinusDM(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MinusDM MinusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod = 14)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.MinusDM(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new MinusDM(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class MinusDM : IndicatorBase
    {
        public MinusDM(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}