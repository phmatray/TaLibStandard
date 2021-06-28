// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlusDM.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines PlusDM.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static PlusDM PlusDM(int startIdx, int endIdx, double[] high, double[] low, int timePeriod = 14)
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
                outReal);
            return new PlusDM(retCode, outBegIdx, outNBElement, outReal);
        }

        public static PlusDM PlusDM(int startIdx, int endIdx, float[] high, float[] low, int timePeriod = 14)
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
                outReal);
            return new PlusDM(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class PlusDM : IndicatorBase
    {
        public PlusDM(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}