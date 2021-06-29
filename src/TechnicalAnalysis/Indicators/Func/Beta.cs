﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Beta.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Beta.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Beta Beta(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod = 5)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Beta(
                startIdx,
                endIdx,
                real0,
                real1,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new Beta(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Beta Beta(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod = 5)
            => Beta(startIdx, endIdx, real0.ToDouble(), real1.ToDouble(), timePeriod);
    }

    public class Beta : IndicatorBase
    {
        public Beta(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
