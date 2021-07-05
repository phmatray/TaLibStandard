// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlTasukiGap.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlTasukiGap.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlTasukiGap CdlTasukiGap(
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

            CandleTasukiGap candle = new (open, high, low, close);
            RetCode retCode = candle.CdlTasukiGap(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlTasukiGap(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlTasukiGap CdlTasukiGap(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlTasukiGap(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlTasukiGap : IndicatorBase
    {
        public CdlTasukiGap(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
