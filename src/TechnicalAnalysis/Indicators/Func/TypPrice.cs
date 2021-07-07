// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypPrice.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines TypPrice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static TypPrice TypPrice(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.TypPrice(startIdx, endIdx, high, low, close, ref outBegIdx, ref outNBElement, ref outReal);
            return new TypPrice(retCode, outBegIdx, outNBElement, outReal);
        }

        public static TypPrice TypPrice(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => TypPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public record TypPrice : IndicatorBase
    {
        public TypPrice(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
