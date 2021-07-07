// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtDcPeriod.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines HtDcPeriod.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtDcPeriod HtDcPeriod(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtDcPeriod(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new HtDcPeriod(retCode, outBegIdx, outNBElement, outReal);
        }

        public static HtDcPeriod HtDcPeriod(int startIdx, int endIdx, float[] real)
            => HtDcPeriod(startIdx, endIdx, real.ToDouble());
    }

    public record HtDcPeriod : IndicatorBase
    {
        public HtDcPeriod(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
