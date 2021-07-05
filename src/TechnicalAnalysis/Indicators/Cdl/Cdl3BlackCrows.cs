﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3BlackCrows.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3BlackCrows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl3BlackCrows Cdl3BlackCrows(
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

            Candle3BlackCrows candle = new (open, high, low, close);
            RetCode retCode = candle.Cdl3BlackCrows(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new Cdl3BlackCrows(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static Cdl3BlackCrows Cdl3BlackCrows(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => Cdl3BlackCrows(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class Cdl3BlackCrows : IndicatorBase
    {
        public Cdl3BlackCrows(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
