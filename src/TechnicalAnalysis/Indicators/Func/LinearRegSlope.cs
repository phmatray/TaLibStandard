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
    public partial class TAMath
    {
        public static LinearRegSlope LinearRegSlope(int startIdx, int endIdx, double[] real, int timePeriod = 14)
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
                outReal);
            
            return new LinearRegSlope(retCode, outBegIdx, outNBElement, outReal);
        }

        public static LinearRegSlope LinearRegSlope(int startIdx, int endIdx, float[] real, int timePeriod = 14)
            => LinearRegSlope(startIdx, endIdx, real.ToDouble(), timePeriod);
    }

    public class LinearRegSlope : IndicatorBase
    {
        public LinearRegSlope(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
