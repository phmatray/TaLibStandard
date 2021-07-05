// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3LineStrike.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3LineStrike.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl3LineStrike Cdl3LineStrike(
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

            Candle3LineStrike candle = new (open, high, low, close);
            RetCode retCode = candle.Cdl3LineStrike(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new Cdl3LineStrike(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static Cdl3LineStrike Cdl3LineStrike(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => Cdl3LineStrike(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class Cdl3LineStrike : IndicatorBase
    {
        public Cdl3LineStrike(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
