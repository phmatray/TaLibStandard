﻿using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static TanhResult Tanh(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Tanh(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new TanhResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static TanhResult Tanh(int startIdx, int endIdx, float[] real)
            => Tanh(startIdx, endIdx, real.ToDouble());
    }

    public record TanhResult : IndicatorBase
    {
        public TanhResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
