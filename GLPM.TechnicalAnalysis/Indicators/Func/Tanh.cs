// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tanh.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Tanh.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Tanh Tanh(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Tanh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Tanh(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Tanh Tanh(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Tanh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Tanh(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Tanh : IndicatorBase
    {
        public Tanh(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}