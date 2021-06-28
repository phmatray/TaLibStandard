// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WclPrice.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines WclPrice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static WclPrice WclPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.WclPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, outReal);
            return new WclPrice(retCode, outBegIdx, outNBElement, outReal);
        }

        public static WclPrice WclPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.WclPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, outReal);
            return new WclPrice(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class WclPrice : IndicatorBase
    {
        public WclPrice(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
