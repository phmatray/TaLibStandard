// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Atan.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Atan.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Atan Atan(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Atan(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Atan(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Atan Atan(int startIdx, int endIdx, float[] real)
            => Atan(startIdx, endIdx, real.ToDouble());
    }

    public record Atan : IndicatorBase
    {
        public Atan(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
