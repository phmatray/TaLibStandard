﻿using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static RocPResult RocP(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.RocP(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new RocPResult(retCode, outBegIdx, outNBElement, outReal);
        }
        
        public static RocPResult RocP(int startIdx, int endIdx, double[] real)
            => RocP(startIdx, endIdx, real, 10);

        public static RocPResult RocP(int startIdx, int endIdx, float[] real, int timePeriod)
            => RocP(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static RocPResult RocP(int startIdx, int endIdx, float[] real)
            => RocP(startIdx, endIdx, real, 10);
    }

    public record RocPResult : IndicatorBase
    {
        public RocPResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
