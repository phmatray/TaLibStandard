// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rsi.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Rsi.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Rsi Rsi(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Rsi(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            return new Rsi(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Rsi Rsi(int startIdx, int endIdx, double[] real)
            => Rsi(startIdx, endIdx, real, 14);

        public static Rsi Rsi(int startIdx, int endIdx, float[] real, int timePeriod)
            => Rsi(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Rsi Rsi(int startIdx, int endIdx, float[] real)
            => Rsi(startIdx, endIdx, real, 14);
    }

    public record Rsi : IndicatorBase
    {
        public Rsi(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
