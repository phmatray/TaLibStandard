// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlGapSideSideWhite.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlGapSideSideWhite.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlGapSideSideWhite CdlGapSideSideWhite(
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

            CandleGapSideSideWhite candle = new (open, high, low, close);
            RetCode retCode = candle.CdlGapSideSideWhite(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlGapSideSideWhite(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlGapSideSideWhite CdlGapSideSideWhite(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlGapSideSideWhite(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble());
    }

    public class CdlGapSideSideWhite : IndicatorBase
    {
        public CdlGapSideSideWhite(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
