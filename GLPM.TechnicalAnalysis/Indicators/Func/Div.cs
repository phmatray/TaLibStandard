// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Div.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Div.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Div Div(int startIdx, int endIdx, double[] real0, double[] real1)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Div(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, outReal);
            return new Div(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Div Div(int startIdx, int endIdx, float[] real0, float[] real1)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Div(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, outReal);
            return new Div(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Div : IndicatorBase
    {
        public Div(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}