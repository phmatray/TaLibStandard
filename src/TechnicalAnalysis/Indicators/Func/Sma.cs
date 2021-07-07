// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sma.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines the TechnicalAnalysis type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Sma Sma(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Sma(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Sma Sma(int startIdx, int endIdx, double[] real)
            => Sma(startIdx, endIdx, real, 30);

        public static Sma Sma(int startIdx, int endIdx, float[] real, int timePeriod)
            => Sma(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Sma Sma(int startIdx, int endIdx, float[] real)
            => Sma(startIdx, endIdx, real, 30);
    }

    public record Sma : IndicatorBase
    {
        public Sma(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
