// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Kama.cs" company="GLPM">
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
        public static Kama Kama(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Kama(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Kama(retCode, outBegIdx, outNBElement, outReal);
        }
        
        public static Kama Kama(int startIdx, int endIdx, double[] real)
            => Kama(startIdx, endIdx, real, 30);

        public static Kama Kama(int startIdx, int endIdx, float[] real, int timePeriod)
            => Kama(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Kama Kama(int startIdx, int endIdx, float[] real)
            => Kama(startIdx, endIdx, real, 30);
    }

    public record Kama : IndicatorBase
    {
        public Kama(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
