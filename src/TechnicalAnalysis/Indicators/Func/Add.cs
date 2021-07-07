// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Add.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Add.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Add Add(int startIdx, int endIdx, double[] real0, double[] real1)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Add(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Add(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Add Add(int startIdx, int endIdx, float[] real0, float[] real1)
            => Add(startIdx, endIdx, real0.ToDouble(), real1.ToDouble());
    }

    public record Add : IndicatorBase
    {
        public Add(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
