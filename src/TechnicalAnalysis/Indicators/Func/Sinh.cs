// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sinh.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Sinh.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Sinh Sinh(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sinh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            
            return new Sinh(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Sinh Sinh(int startIdx, int endIdx, float[] real)
            => Sinh(startIdx, endIdx, real.ToDouble());
    }

    public class Sinh : IndicatorBase
    {
        public Sinh(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
