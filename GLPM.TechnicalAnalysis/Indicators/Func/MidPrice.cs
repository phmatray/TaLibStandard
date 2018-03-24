// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MidPrice.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MidPrice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MidPrice MidPrice(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            int timePeriod = 14)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.MidPrice(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new MidPrice(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MidPrice MidPrice(int startIdx, int endIdx, float[] high, float[] low, int timePeriod = 14)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.MidPrice(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new MidPrice(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class MidPrice : IndicatorBase
    {
        public MidPrice(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}