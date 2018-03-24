// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cmo.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cmo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Cmo Cmo(int startIdx, int endIdx, double[] real, int timePeriod = 14)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Cmo(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Cmo(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Cmo Cmo(int startIdx, int endIdx, float[] real, int timePeriod = 14)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Cmo(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Cmo(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Cmo : IndicatorBase
    {
        public Cmo(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}