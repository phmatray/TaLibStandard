// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypPrice.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines TypPrice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static TypPrice TypPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.TypPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, outReal);
            return new TypPrice(retCode, outBegIdx, outNBElement, outReal);
        }

        public static TypPrice TypPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.TypPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, outReal);
            return new TypPrice(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class TypPrice : IndicatorBase
    {
        public TypPrice(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}