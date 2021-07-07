// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Sar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Sar Sar(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double acceleration,
            double maximum)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sar(
                startIdx,
                endIdx,
                high,
                low,
                acceleration,
                maximum,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new Sar(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Sar Sar(int startIdx, int endIdx, double[] high, double[] low)
            => Sar(startIdx, endIdx, high, low, 0.02, 0.2);

        public static Sar Sar(int startIdx, int endIdx, float[] high, float[] low, double acceleration, double maximum)
            => Sar(startIdx, endIdx, high.ToDouble(), low.ToDouble(), acceleration, maximum);
        
        public static Sar Sar(int startIdx, int endIdx, float[] high, float[] low)
            => Sar(startIdx, endIdx, high, low, 0.02, 0.2);
    }

    public record Sar : IndicatorBase
    {
        public Sar(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
