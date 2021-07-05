// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtTrendMode.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines HtTrendMode.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtTrendMode HtTrendMode(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtTrendMode(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new HtTrendMode(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static HtTrendMode HtTrendMode(int startIdx, int endIdx, float[] real)
            => HtTrendMode(startIdx, endIdx, real.ToDouble());
    }

    public class HtTrendMode : IndicatorBase
    {
        public HtTrendMode(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
