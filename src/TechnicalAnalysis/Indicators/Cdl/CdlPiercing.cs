// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlPiercing.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlPiercing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlPiercing CdlPiercing(
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

            CandlePiercing candle = new (open, high, low, close);
            RetCode retCode = candle.CdlPiercing(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlPiercing(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlPiercing CdlPiercing(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlPiercing(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlPiercing : IndicatorBase
    {
        public CdlPiercing(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
