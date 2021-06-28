// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StdDev.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines StdDev.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static StdDev StdDev(
            int startIdx,
            int endIdx,
            double[] real,
            int timePeriod = 5,
            double nbDev = 1.0)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.StdDev(
                startIdx,
                endIdx,
                real,
                timePeriod,
                nbDev,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new StdDev(retCode, outBegIdx, outNBElement, outReal);
        }

        public static StdDev StdDev(
            int startIdx,
            int endIdx,
            float[] real,
            int timePeriod = 5,
            double nbDev = 1.0)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.StdDev(
                startIdx,
                endIdx,
                real,
                timePeriod,
                nbDev,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new StdDev(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class StdDev : IndicatorBase
    {
        public StdDev(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
