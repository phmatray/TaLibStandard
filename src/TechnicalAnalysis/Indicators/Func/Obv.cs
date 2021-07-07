// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Obv.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Obv.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Obv Obv(int startIdx, int endIdx, double[] real, double[] volume)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Obv(startIdx, endIdx, real, volume, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Obv(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Obv Obv(int startIdx, int endIdx, float[] real, float[] volume)
            => Obv(startIdx, endIdx, real.ToDouble(), volume.ToDouble());
    }

    public record Obv : IndicatorBase
    {
        public Obv(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
