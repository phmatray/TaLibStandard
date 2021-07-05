// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cos.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cos.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cos Cos(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Cos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Cos(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Cos Cos(int startIdx, int endIdx, float[] real)
            => Cos(startIdx, endIdx, real.ToDouble());
    }

    public class Cos : IndicatorBase
    {
        public Cos(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
