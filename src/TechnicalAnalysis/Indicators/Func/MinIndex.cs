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
    public static partial class TAMath
    {
        public static MinIndex MinIndex(int startIdx, int endIdx, double[] real, int timePeriod)
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
                ref outInteger);
            
            return new MinIndex(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static MinIndex MinIndex(int startIdx, int endIdx, double[] real)
            => MinIndex(startIdx, endIdx, real, 30);

        public static MinIndex MinIndex(int startIdx, int endIdx, float[] real, int timePeriod)
            => MinIndex(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static MinIndex MinIndex(int startIdx, int endIdx, float[] real)
            => MinIndex(startIdx, endIdx, real, 30);
    }

    public record MinIndex : IndicatorBase
    {
        public MinIndex(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
