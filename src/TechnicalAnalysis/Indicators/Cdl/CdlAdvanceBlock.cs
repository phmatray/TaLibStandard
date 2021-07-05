﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlAdvanceBlock.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlAdvanceBlock.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlAdvanceBlock CdlAdvanceBlock(
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

            CandleAdvanceBlock candle = new (open, high, low, close);
            RetCode retCode = candle.CdlAdvanceBlock(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlAdvanceBlock(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlAdvanceBlock CdlAdvanceBlock(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlAdvanceBlock(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlAdvanceBlock : IndicatorBase
    {
        public CdlAdvanceBlock(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
