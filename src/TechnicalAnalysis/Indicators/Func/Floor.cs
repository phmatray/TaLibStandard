// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Floor.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Floor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Floor Floor(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Floor(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Floor(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Floor Floor(int startIdx, int endIdx, float[] real)
            => Floor(startIdx, endIdx, real.ToDouble());
    }

    public class Floor : IndicatorBase
    {
        public Floor(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
