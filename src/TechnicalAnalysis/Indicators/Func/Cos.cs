// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cos.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cos.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Cos Cos(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Cos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Cos(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Cos Cos(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Cos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Cos(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Cos : IndicatorBase
    {
        public Cos(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}