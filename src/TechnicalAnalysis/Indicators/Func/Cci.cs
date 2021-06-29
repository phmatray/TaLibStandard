// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cci.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cci.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cci Cci(int startIdx, int endIdx, double[] high, double[] low, double[] close, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Cci(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new Cci(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Cci Cci(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => Cci(startIdx, endIdx, high, low, close, 14);

        public static Cci Cci(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
            => Cci(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);

        public static Cci Cci(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => Cci(startIdx, endIdx, high, low, close, 14);
    }

    public class Cci : IndicatorBase
    {
        public Cci(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
