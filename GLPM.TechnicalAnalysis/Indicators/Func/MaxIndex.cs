// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MaxIndex.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MaxIndex.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MaxIndex MaxIndex(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.MaxIndex(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new MaxIndex(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static MaxIndex MaxIndex(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.MaxIndex(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new MaxIndex(retCode, outBegIdx, outNBElement, outInteger);
        }
    }

    public class MaxIndex : IndicatorBase
    {
        public MaxIndex(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}