// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl2Crows.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl2Crows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl2Crows Cdl2Crows(
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

            Candle2Crows candle = new (open, high, low, close);
            RetCode retCode = candle.Cdl2Crows(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);

            return new Cdl2Crows(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static Cdl2Crows Cdl2Crows(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => Cdl2Crows(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class Cdl2Crows : IndicatorBase
    {
        public Cdl2Crows(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
