// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Sar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Sar Sar(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double acceleration = 0.02,
            double maximum = 0.2)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Sar(
                startIdx,
                endIdx,
                high,
                low,
                acceleration,
                maximum,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new Sar(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Sar Sar(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            double acceleration = 0.02,
            double maximum = 0.2)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Sar(
                startIdx,
                endIdx,
                high,
                low,
                acceleration,
                maximum,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new Sar(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Sar : IndicatorBase
    {
        public Sar(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}