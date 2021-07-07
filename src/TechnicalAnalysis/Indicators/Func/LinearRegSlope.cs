// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearRegSlope.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines LinearRegSlope.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static LinearRegSlope LinearRegSlope(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.LinearRegSlope(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new LinearRegSlope(retCode, outBegIdx, outNBElement, outReal);
        }

        public static LinearRegSlope LinearRegSlope(int startIdx, int endIdx, double[] real)
            => LinearRegSlope(startIdx, endIdx, real, 14);

        public static LinearRegSlope LinearRegSlope(int startIdx, int endIdx, float[] real, int timePeriod)
            => LinearRegSlope(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static LinearRegSlope LinearRegSlope(int startIdx, int endIdx, float[] real)
            => LinearRegSlope(startIdx, endIdx, real, 14);
    }

    public record LinearRegSlope : IndicatorBase
    {
        public LinearRegSlope(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
