// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Atr.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Atr.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Atr Atr(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Atr(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new Atr(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Atr Atr(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => Atr(startIdx, endIdx, high, low, close, 14);

        public static Atr Atr(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
            => Atr(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

        public static Atr Atr(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => Atr(startIdx, endIdx, high, low, close, 14);
    }

    public class Atr : IndicatorBase
    {
        public Atr(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
