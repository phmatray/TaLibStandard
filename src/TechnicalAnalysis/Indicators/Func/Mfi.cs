// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mfi.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Mfi.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Mfi Mfi(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            double[] volume,
            int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Mfi(
                startIdx,
                endIdx,
                high,
                low,
                close,
                volume,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new Mfi(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Mfi Mfi(int startIdx, int endIdx, double[] high, double[] low, double[] close, double[] volume)
            => Mfi(startIdx, endIdx, high, low, close, volume, 14);

        public static Mfi Mfi(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            float[] volume,
            int timePeriod)
            => Mfi(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), volume.ToDouble(), timePeriod);
        
        public static Mfi Mfi(int startIdx, int endIdx, float[] high, float[] low, float[] close, float[] volume)
            => Mfi(startIdx, endIdx, high, low, close, volume, 14);
    }

    public class Mfi : IndicatorBase
    {
        public Mfi(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
