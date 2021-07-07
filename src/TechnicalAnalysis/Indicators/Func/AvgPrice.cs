// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvgPrice.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines AvgPrice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static AvgPrice AvgPrice(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.AvgPrice(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new AvgPrice(retCode, outBegIdx, outNBElement, outReal);
        }

        public static AvgPrice AvgPrice(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => AvgPrice(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public record AvgPrice : IndicatorBase
    {
        public AvgPrice(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
