// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TrueRange.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines TrueRange.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static TrueRange TrueRange(int startIdx, int endIdx, double[] high, double[] low, double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.TrueRange(
                startIdx,
                endIdx,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new TrueRange(retCode, outBegIdx, outNBElement, outReal);
        }

        public static TrueRange TrueRange(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => TrueRange(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public record TrueRange : IndicatorBase
    {
        public TrueRange(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
