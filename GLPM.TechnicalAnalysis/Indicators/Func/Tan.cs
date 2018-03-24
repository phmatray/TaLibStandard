// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tan.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Tan.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Tan Tan(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Tan(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Tan(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Tan Tan(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Tan(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Tan(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Tan : IndicatorBase
    {
        public Tan(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}