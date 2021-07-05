﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlConcealBabySwallow.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlConcealBabySwallow.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlConcealBabySwallow CdlConcealBabySwallow(
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

            CandleConcealBabySwallow candle = new (open, high, low, close);
            RetCode retCode = candle.CdlConcealBabySwallow(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlConcealBabySwallow(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlConcealBabySwallow CdlConcealBabySwallow(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlConcealBabySwallow(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble());
    }

    public class CdlConcealBabySwallow : IndicatorBase
    {
        public CdlConcealBabySwallow(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
