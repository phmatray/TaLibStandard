// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Asin.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Asin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Asin Asin(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Asin(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Asin(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Asin Asin(int startIdx, int endIdx, float[] real)
            => Asin(startIdx, endIdx, real.ToDouble());
    }

    public class Asin : IndicatorBase
    {
        public Asin(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
