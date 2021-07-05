// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3StarsInSouth.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3StarsInSouth.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl3StarsInSouth Cdl3StarsInSouth(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            Candle3StarsInSouth candle = new (open, high, low, close);
            RetCode retCode = candle.Cdl3StarsInSouth(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new Cdl3StarsInSouth(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static Cdl3StarsInSouth Cdl3StarsInSouth(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => Cdl3StarsInSouth(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class Cdl3StarsInSouth : IndicatorBase
    {
        public Cdl3StarsInSouth(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
