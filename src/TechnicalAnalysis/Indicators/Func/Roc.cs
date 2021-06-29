﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Roc.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Roc.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Roc Roc(int startIdx, int endIdx, double[] real, int timePeriod = 10)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Roc(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            
            return new Roc(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Roc Roc(int startIdx, int endIdx, float[] real, int timePeriod = 10)
            => Roc(startIdx, endIdx, real.ToDouble(), timePeriod);
    }

    public class Roc : IndicatorBase
    {
        public Roc(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
