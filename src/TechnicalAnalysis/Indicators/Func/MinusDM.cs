﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinusDM.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MinusDM.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MinusDM MinusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinusDM(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new MinusDM(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MinusDM MinusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod = 14)
            => MinusDM(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);
    }

    public class MinusDM : IndicatorBase
    {
        public MinusDM(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
