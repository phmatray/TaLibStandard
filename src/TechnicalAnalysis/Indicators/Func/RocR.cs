﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RocR.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines RocR.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static RocR RocR(int startIdx, int endIdx, double[] real, int timePeriod = 10)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.RocR(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            
            return new RocR(retCode, outBegIdx, outNBElement, outReal);
        }

        public static RocR RocR(int startIdx, int endIdx, float[] real, int timePeriod = 10)
            => RocR(startIdx, endIdx, real.ToDouble(), timePeriod);
    }

    public class RocR : IndicatorBase
    {
        public RocR(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
