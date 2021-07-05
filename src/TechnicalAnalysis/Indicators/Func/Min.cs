// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Min.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Min.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Min Min(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Min(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Min(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Min Min(int startIdx, int endIdx, double[] real)
            => Min(startIdx, endIdx, real, 30);

        public static Min Min(int startIdx, int endIdx, float[] real, int timePeriod)
            => Min(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Min Min(int startIdx, int endIdx, float[] real)
            => Min(startIdx, endIdx, real, 30);
    }

    public class Min : IndicatorBase
    {
        public Min(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
