﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlMarubozu.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlMarubozu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlMarubozu CdlMarubozu(
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

            CandleMarubozu candle = new (open, high, low, close);
            RetCode retCode = candle.CdlMarubozu(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlMarubozu(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlMarubozu CdlMarubozu(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlMarubozu(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlMarubozu : IndicatorBase
    {
        public CdlMarubozu(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
