﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mom.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Mom.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Mom Mom(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Mom(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Mom(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Mom Mom(int startIdx, int endIdx, double[] real)
            => Mom(startIdx, endIdx, real, 10);

        public static Mom Mom(int startIdx, int endIdx, float[] real, int timePeriod)
            => Mom(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Mom Mom(int startIdx, int endIdx, float[] real)
            => Mom(startIdx, endIdx, real, 10);
    }

    public class Mom : IndicatorBase
    {
        public Mom(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
