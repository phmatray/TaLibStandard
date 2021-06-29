﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Trix.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Trix.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Trix Trix(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Trix(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            
            return new Trix(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Trix Trix(int startIdx, int endIdx, float[] real, int timePeriod = 30)
            => Trix(startIdx, endIdx, real.ToDouble(), timePeriod);
    }

    public class Trix : IndicatorBase
    {
        public Trix(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
