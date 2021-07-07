// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlusDM.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines PlusDM.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static PlusDM PlusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.PlusDM(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new PlusDM(retCode, outBegIdx, outNBElement, outReal);
        }

        public static PlusDM PlusDM(int startIdx, int endIdx, double[] high, double[] low)
            => PlusDM(startIdx, endIdx, high, low, 14);

        public static PlusDM PlusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
            => PlusDM(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);

        public static PlusDM PlusDM(int startIdx, int endIdx, float[] high, float[] low)
            => PlusDM(startIdx, endIdx, high, low, 14);
    }

    public record PlusDM : IndicatorBase
    {
        public PlusDM(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
