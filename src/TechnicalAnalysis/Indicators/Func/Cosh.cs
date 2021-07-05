// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cosh.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cosh.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cosh Cosh(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Cosh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Cosh(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Cosh Cosh(int startIdx, int endIdx, float[] real)
            => Cosh(startIdx, endIdx, real.ToDouble());
    }

    public class Cosh : IndicatorBase
    {
        public Cosh(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
