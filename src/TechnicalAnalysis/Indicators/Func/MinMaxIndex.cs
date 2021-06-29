// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinMaxIndex.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MinMaxIndex.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MinMaxIndex MinMaxIndex(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outMinIdx = new int[endIdx - startIdx + 1];
            int[] outMaxIdx = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinMaxIndex(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outMinIdx,
                outMaxIdx);
            
            return new MinMaxIndex(retCode, outBegIdx, outNBElement, outMinIdx, outMaxIdx);
        }
        
        public static MinMaxIndex MinMaxIndex(int startIdx, int endIdx, double[] real)
            => MinMaxIndex(startIdx, endIdx, real, 30);

        public static MinMaxIndex MinMaxIndex(int startIdx, int endIdx, float[] real, int timePeriod)
            => MinMaxIndex(startIdx, endIdx, real.ToDouble(), timePeriod);        

        public static MinMaxIndex MinMaxIndex(int startIdx, int endIdx, float[] real)
            => MinMaxIndex(startIdx, endIdx, real, 30);
    }

    public class MinMaxIndex : IndicatorBase
    {
        public MinMaxIndex(RetCode retCode, int begIdx, int nbElement, int[] minIdx, int[] maxIdx)
            : base(retCode, begIdx, nbElement)
        {
            this.MinIdx = minIdx;
            this.MaxIdx = maxIdx;
        }

        public int[] MaxIdx { get; }

        public int[] MinIdx { get; }
    }
}
