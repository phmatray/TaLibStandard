// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ln.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Ln.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Ln Ln(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Ln(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Ln(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Ln Ln(int startIdx, int endIdx, float[] real)
            => Ln(startIdx, endIdx, real.ToDouble());
    }

    public class Ln : IndicatorBase
    {
        public Ln(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
