// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MidPoint.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MidPoint.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MidPoint MidPoint(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MidPoint(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            return new MidPoint(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MidPoint MidPoint(int startIdx, int endIdx, double[] real)
            => MidPoint(startIdx, endIdx, real, 14);

        public static MidPoint MidPoint(int startIdx, int endIdx, float[] real, int timePeriod)
            => MidPoint(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static MidPoint MidPoint(int startIdx, int endIdx, float[] real)
            => MidPoint(startIdx, endIdx, real, 14);
    }

    public record MidPoint : IndicatorBase
    {
        public MidPoint(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
