// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearRegAngle.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines LinearRegAngle.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static LinearRegAngle LinearRegAngle(int startIdx, int endIdx, double[] real, int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.LinearRegAngle(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new LinearRegAngle(retCode, outBegIdx, outNBElement, outReal);
        }

        public static LinearRegAngle LinearRegAngle(int startIdx, int endIdx, float[] real, int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.LinearRegAngle(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new LinearRegAngle(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class LinearRegAngle : IndicatorBase
    {
        public LinearRegAngle(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}