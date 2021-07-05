﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlInvertedHammer.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlInvertedHammer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlInvertedHammer CdlInvertedHammer(
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

            CandleInvertedHammer candle = new (open, high, low, close);
            RetCode retCode = candle.CdlInvertedHammer(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlInvertedHammer(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlInvertedHammer CdlInvertedHammer(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlInvertedHammer(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlInvertedHammer : IndicatorBase
    {
        public CdlInvertedHammer(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
