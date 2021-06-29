// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tsf.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Tsf.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Tsf Tsf(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Tsf(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Tsf(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Tsf Tsf(int startIdx, int endIdx, double[] real)
            => Tsf(startIdx, endIdx, real, 14);

        public static Tsf Tsf(int startIdx, int endIdx, float[] real, int timePeriod)
            => Tsf(startIdx, endIdx, real.ToDouble(), timePeriod);
            
        public static Tsf Tsf(int startIdx, int endIdx, float[] real)
            => Tsf(startIdx, endIdx, real, 14);
    }

    public class Tsf : IndicatorBase
    {
        public Tsf(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
