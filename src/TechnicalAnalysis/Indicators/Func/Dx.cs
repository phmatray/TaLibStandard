// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dx.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Dx.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Dx Dx(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Dx(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new Dx(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Dx Dx(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => Dx(startIdx, endIdx, high, low, close, 14);

        public static Dx Dx(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
            => Dx(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

        public static Dx Dx(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => Dx(startIdx, endIdx, high, low, close, 14);
    }

    public class Dx : IndicatorBase
    {
        public Dx(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
