// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ema.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Ema.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Ema Ema(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Ema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Ema(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Ema Ema(int startIdx, int endIdx, double[] real)
            => Ema(startIdx, endIdx, real, 30);

        public static Ema Ema(int startIdx, int endIdx, float[] real, int timePeriod)
            => Ema(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Ema Ema(int startIdx, int endIdx, float[] real)
            => Ema(startIdx, endIdx, real, 30);
    }

    public record Ema : IndicatorBase
    {
        public Ema(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
