﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlTristar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlTristar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlTristar CdlTristar(
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

            CandleTristar candle = new (open, high, low, close);
            RetCode retCode = candle.CdlTristar(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlTristar(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlTristar CdlTristar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlTristar(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlTristar : IndicatorBase
    {
        public CdlTristar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
