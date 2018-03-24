// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sum.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Sum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Sum Sum(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Sum(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Sum(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Sum Sum(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Sum(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Sum(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Sum : IndicatorBase
    {
        public Sum(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}