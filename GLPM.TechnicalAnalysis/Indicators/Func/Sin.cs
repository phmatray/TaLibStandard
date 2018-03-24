// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sin.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Sin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Sin Sin(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Sin(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Sin(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Sin Sin(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Sin(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Sin(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Sin : IndicatorBase
    {
        public Sin(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}