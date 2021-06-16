// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ad.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Ad.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Ad Ad(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            double[] volume)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Ad(
                startIdx,
                endIdx,
                high,
                low,
                close,
                volume,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new Ad(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Ad Ad(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Ad(
                startIdx,
                endIdx,
                high,
                low,
                close,
                volume,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new Ad(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Ad : IndicatorBase
    {
        public Ad(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}