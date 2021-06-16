// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Exp.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Exp.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Exp Exp(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Exp(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Exp(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Exp Exp(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Exp(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Exp(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Exp : IndicatorBase
    {
        public Exp(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}