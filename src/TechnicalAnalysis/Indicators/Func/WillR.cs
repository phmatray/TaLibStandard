﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WillR.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines WillR.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static WillR WillR(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.WillR(
                startIdx,
                endIdx,
                high,
                low,
                close,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new WillR(retCode, outBegIdx, outNBElement, outReal);
        }

        public static WillR WillR(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => WillR(startIdx, endIdx, high, low, close, 14);

        public static WillR WillR(int startIdx, int endIdx, float[] high, float[] low, float[] close, int timePeriod)
            => WillR(startIdx, endIdx, high.ToDouble(), low.ToDouble(), close.ToDouble(), timePeriod);
        
        public static WillR WillR(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => WillR(startIdx, endIdx, high, low, close, 14);
    }

    public class WillR : IndicatorBase
    {
        public WillR(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
