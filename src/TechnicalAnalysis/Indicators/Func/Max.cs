// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Max.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Max.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Max Max(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Max(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            
            return new Max(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Max Max(int startIdx, int endIdx, double[] real)
            => Max(startIdx, endIdx, real, 30);

        public static Max Max(int startIdx, int endIdx, float[] real, int timePeriod)
            => Max(startIdx, endIdx, real.ToDouble(), timePeriod);

        public static Max Max(int startIdx, int endIdx, float[] real)
            => Max(startIdx, endIdx, real, 30);
    }

    public class Max : IndicatorBase
    {
        public Max(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
