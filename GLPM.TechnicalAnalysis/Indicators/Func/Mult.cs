// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mult.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Mult.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Mult Mult(int startIdx, int endIdx, double[] real0, double[] real1)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Mult(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, outReal);
            return new Mult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Mult Mult(int startIdx, int endIdx, float[] real0, float[] real1)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Mult(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, outReal);
            return new Mult(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Mult : IndicatorBase
    {
        public Mult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}