// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearRegAngle.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines LinearRegAngle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static LinearRegAngle LinearRegAngle(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.LinearRegAngle(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new LinearRegAngle(retCode, outBegIdx, outNBElement, outReal);
        }

        public static LinearRegAngle LinearRegAngle(int startIdx, int endIdx, double[] real)
            => LinearRegAngle(startIdx, endIdx, real, 14);

        public static LinearRegAngle LinearRegAngle(int startIdx, int endIdx, float[] real, int timePeriod)
            => LinearRegAngle(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static LinearRegAngle LinearRegAngle(int startIdx, int endIdx, float[] real)
            => LinearRegAngle(startIdx, endIdx, real, 14);
    }

    public record LinearRegAngle : IndicatorBase
    {
        public LinearRegAngle(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
