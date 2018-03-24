// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dema.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Dema.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Dema Dema(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Dema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Dema(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Dema Dema(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Dema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Dema(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Dema : IndicatorBase
    {
        public Dema(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}