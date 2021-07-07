// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sma.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines the TechnicalAnalysis type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static SmaResult Sma(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new SmaResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SmaResult Sma(int startIdx, int endIdx, double[] real)
            => Sma(startIdx, endIdx, real, 30);

        public static SmaResult Sma(int startIdx, int endIdx, float[] real, int timePeriod)
            => Sma(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static SmaResult Sma(int startIdx, int endIdx, float[] real)
            => Sma(startIdx, endIdx, real, 30);
    }

    public record SmaResult : IndicatorBase
    {
        public SmaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
