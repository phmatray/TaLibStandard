// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Adxr.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Adxr.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Adxr Adxr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Adxr(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new Adxr(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Adxr Adxr(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => Adxr(startIdx, endIdx, high, low, close, 14);

        public static Adxr Adxr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
            => Adxr(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);
        
        public static Adxr Adxr(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => Adxr(startIdx, endIdx, high, low, close, 14);
    }

    public record Adxr : IndicatorBase
    {
        public Adxr(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
