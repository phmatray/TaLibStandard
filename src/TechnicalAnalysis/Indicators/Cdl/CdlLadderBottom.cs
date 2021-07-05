﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlLadderBottom.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlLadderBottom.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlLadderBottom CdlLadderBottom(
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

            CandleLadderBottom candle = new (open, high, low, close);
            RetCode retCode = candle.CdlLadderBottom(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlLadderBottom(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlLadderBottom CdlLadderBottom(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlLadderBottom(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlLadderBottom : IndicatorBase
    {
        public CdlLadderBottom(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
