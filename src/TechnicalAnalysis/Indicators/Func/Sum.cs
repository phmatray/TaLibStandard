﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sum.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Sum.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Sum Sum(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sum(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            
            return new Sum(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Sum Sum(int startIdx, int endIdx, double[] real)
            => Sum(startIdx, endIdx, real, 30);

        public static Sum Sum(int startIdx, int endIdx, float[] real, int timePeriod)
            => Sum(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Sum Sum(int startIdx, int endIdx, float[] real)
            => Sum(startIdx, endIdx, real, 30);
    }

    public class Sum : IndicatorBase
    {
        public Sum(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}