// --------------------------------------------------------------------------------------------------------------------
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
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close,
            double penetration)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            CandleMatHold candle = new (open, high, low, close);
            RetCode retCode = candle.CdlMatHold(
                startIdx,
                endIdx,
                penetration,
                ref outBegIdx,
                ref outNBElement,
                ref outInteger);
            
            return new CdlMatHold(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlMatHold CdlMatHold(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
            => CdlMatHold(startIdx, endIdx, open, high, low, close, 0.5);

        public static CdlMatHold CdlMatHold(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close,
            double penetration)
            => CdlMatHold(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                penetration);
        
        public static CdlMatHold CdlMatHold(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlMatHold(startIdx, endIdx, open, high, low, close, 0.5);
    }

    public class CdlMatHold : IndicatorBase
    {
        public CdlMatHold(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
