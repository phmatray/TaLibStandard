// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cci.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cci.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Cci Cci(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int timePeriod = 14)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Cci(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new Cci(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Cci Cci(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            int timePeriod = 14)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Cci(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new Cci(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Cci : IndicatorBase
    {
        public Cci(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}