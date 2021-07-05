// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlInNeck.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlInNeck.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlInNeck CdlInNeck(
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

            CandleInNeck candle = new (open, high, low, close);
            RetCode retCode = candle.CdlInNeck(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlInNeck(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlInNeck CdlInNeck(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlInNeck(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlInNeck : IndicatorBase
    {
        public CdlInNeck(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
