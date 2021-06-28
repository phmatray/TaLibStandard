// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearRegIntercept.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines LinearRegIntercept.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static LinearRegIntercept LinearRegIntercept(
            int startIdx,
            int endIdx,
            double[] real,
            int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.LinearRegIntercept(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new LinearRegIntercept(retCode, outBegIdx, outNBElement, outReal);
        }

        public static LinearRegIntercept LinearRegIntercept(
            int startIdx,
            int endIdx,
            float[] real,
            int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.LinearRegIntercept(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new LinearRegIntercept(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class LinearRegIntercept : IndicatorBase
    {
        public LinearRegIntercept(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}