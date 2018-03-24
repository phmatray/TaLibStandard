// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wma.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Wma.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Wma Wma(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Wma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Wma(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Wma Wma(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Wma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Wma(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Wma : IndicatorBase
    {
        public Wma(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}