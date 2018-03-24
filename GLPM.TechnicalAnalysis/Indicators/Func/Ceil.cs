// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ceil.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Ceil.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Ceil Ceil(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Ceil(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Ceil(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Ceil Ceil(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Ceil(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Ceil(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Ceil : IndicatorBase
    {
        public Ceil(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}