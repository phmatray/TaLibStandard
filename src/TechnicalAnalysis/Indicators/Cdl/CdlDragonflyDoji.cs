﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlDragonflyDoji.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlDragonflyDoji.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlDragonflyDoji CdlDragonflyDoji(
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

            CandleDragonflyDoji candle = new (open, high, low, close);
            RetCode retCode = candle.CdlDragonflyDoji(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlDragonflyDoji(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlDragonflyDoji CdlDragonflyDoji(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlDragonflyDoji(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlDragonflyDoji : IndicatorBase
    {
        public CdlDragonflyDoji(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
