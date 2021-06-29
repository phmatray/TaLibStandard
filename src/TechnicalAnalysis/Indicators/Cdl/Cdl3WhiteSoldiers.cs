﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3WhiteSoldiers.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3WhiteSoldiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl3WhiteSoldiers Cdl3WhiteSoldiers(
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

            RetCode retCode = TACore.Cdl3WhiteSoldiers(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            
            return new Cdl3WhiteSoldiers(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static Cdl3WhiteSoldiers Cdl3WhiteSoldiers(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => Cdl3WhiteSoldiers(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class Cdl3WhiteSoldiers : IndicatorBase
    {
        public Cdl3WhiteSoldiers(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}