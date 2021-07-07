﻿using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static TrimaResult Trima(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Trima(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new TrimaResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static TrimaResult Trima(int startIdx, int endIdx, double[] real)
            => Trima(startIdx, endIdx, real, 30);

        public static TrimaResult Trima(int startIdx, int endIdx, float[] real, int timePeriod)
            => Trima(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static TrimaResult Trima(int startIdx, int endIdx, float[] real)
            => Trima(startIdx, endIdx, real, 30);
    }

    public record TrimaResult : IndicatorBase
    {
        public TrimaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
