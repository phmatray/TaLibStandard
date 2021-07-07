// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Beta.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Beta.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Beta Beta(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Beta(
                startIdx,
                endIdx,
                real0,
                real1,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new Beta(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Beta Beta(int startIdx, int endIdx, double[] real0, double[] real1)
            => Beta(startIdx, endIdx, real0, real1, 5);

        public static Beta Beta(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod)
            => Beta(startIdx, endIdx, real0.ToDouble(), real1.ToDouble(), timePeriod);
        
        public static Beta Beta(int startIdx, int endIdx, float[] real0, float[] real1)
            => Beta(startIdx, endIdx, real0, real1, 5);
    }

    public record Beta : IndicatorBase
    {
        public Beta(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
