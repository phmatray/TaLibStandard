﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlBreakaway.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlBreakaway.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlBreakaway CdlBreakaway(
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

            CandleBreakaway candle = new (open, high, low, close);
            RetCode retCode = candle.CdlBreakaway(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlBreakaway(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlBreakaway CdlBreakaway(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlBreakaway(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlBreakaway : IndicatorBase
    {
        public CdlBreakaway(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
