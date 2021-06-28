// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinIndex.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MinIndex.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MinIndex MinIndex(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinIndex(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new MinIndex(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static MinIndex MinIndex(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinIndex(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new MinIndex(retCode, outBegIdx, outNBElement, outInteger);
        }
    }

    public class MinIndex : IndicatorBase
    {
        public MinIndex(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
