﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlMatHold.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlMatHold.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlMatHold CdlMatHold(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleMatHold(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlMatHold(retCode, begIdx, nbElement, ints);
        }

        public static CdlMatHold CdlMatHold(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlMatHold(startIdx, endIdx, open, high, low, close, 0.5);
        }

        public static CdlMatHold CdlMatHold(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlMatHold(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CdlMatHold CdlMatHold(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlMatHold(startIdx, endIdx, open, high, low, close, 0.5);
        }
    }

    public record CdlMatHold : IndicatorBase
    {
        public CdlMatHold(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
