﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlSeparatingLines.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlSeparatingLines.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlSeparatingLines CdlSeparatingLines(
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

            RetCode retCode = TACore.CdlSeparatingLines(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            
            return new CdlSeparatingLines(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlSeparatingLines CdlSeparatingLines(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlSeparatingLines(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlSeparatingLines : IndicatorBase
    {
        public CdlSeparatingLines(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}