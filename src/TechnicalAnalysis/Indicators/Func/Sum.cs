﻿using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static SumResult Sum(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sum(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new SumResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SumResult Sum(int startIdx, int endIdx, double[] real)
            => Sum(startIdx, endIdx, real, 30);

        public static SumResult Sum(int startIdx, int endIdx, float[] real, int timePeriod)
            => Sum(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static SumResult Sum(int startIdx, int endIdx, float[] real)
            => Sum(startIdx, endIdx, real, 30);
    }

    public record SumResult : IndicatorBase
    {
        public SumResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
