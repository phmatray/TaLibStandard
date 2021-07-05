// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tan.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Tan.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Tan Tan(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Tan(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Tan(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Tan Tan(int startIdx, int endIdx, float[] real)
            => Tan(startIdx, endIdx, real.ToDouble());
    }

    public class Tan : IndicatorBase
    {
        public Tan(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
