﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Acos.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines the TechnicalAnalysis type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static AcosResult Acos(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Acos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new AcosResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static AcosResult Acos(int startIdx, int endIdx, float[] real)
            => Acos(startIdx, endIdx, real.ToDouble());
    }

    public record AcosResult : IndicatorBase
    {
        public AcosResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
