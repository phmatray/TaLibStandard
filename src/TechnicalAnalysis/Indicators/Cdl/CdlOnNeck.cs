// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlOnNeck.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlOnNeck.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlOnNeck CdlOnNeck(
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

            CandleOnNeck candle = new (open, high, low, close);
            RetCode retCode = candle.CdlOnNeck(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlOnNeck(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlOnNeck CdlOnNeck(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlOnNeck(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlOnNeck : IndicatorBase
    {
        public CdlOnNeck(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
