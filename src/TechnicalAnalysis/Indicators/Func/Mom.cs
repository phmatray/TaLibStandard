// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mom.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Mom.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Mom Mom(int startIdx, int endIdx, double[] real, int timePeriod = 10)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Mom(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Mom(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Mom Mom(int startIdx, int endIdx, float[] real, int timePeriod = 10)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Mom(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Mom(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Mom : IndicatorBase
    {
        public Mom(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}