﻿using TechnicalAnalysis.Common;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MedPriceResult MedPrice(int startIdx, int endIdx, double[] high, double[] low)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MedPrice(startIdx, endIdx, high, low, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new MedPriceResult(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MedPriceResult MedPrice(int startIdx, int endIdx, float[] high, float[] low)
            => MedPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble());
    }

    public record MedPriceResult : IndicatorBase
    {
        public MedPriceResult(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
