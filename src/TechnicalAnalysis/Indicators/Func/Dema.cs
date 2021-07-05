﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dema.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Dema.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Dema Dema(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Dema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Dema(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Dema Dema(int startIdx, int endIdx, double[] real)
            => Dema(startIdx, endIdx, real, 30);

        public static Dema Dema(int startIdx, int endIdx, float[] real, int timePeriod)
            => Dema(startIdx, endIdx, real.ToDouble(), timePeriod);

        public static Dema Dema(int startIdx, int endIdx, float[] real)
            => Dema(startIdx, endIdx, real, 30);
    }

    public class Dema : IndicatorBase
    {
        public Dema(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
