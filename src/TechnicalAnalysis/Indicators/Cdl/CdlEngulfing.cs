// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlEngulfing.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlEngulfing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlEngulfing CdlEngulfing(
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

            CandleEngulfing candle = new (open, high, low, close);
            RetCode retCode = candle.CdlEngulfing(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlEngulfing(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlEngulfing CdlEngulfing(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlEngulfing(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlEngulfing : IndicatorBase
    {
        public CdlEngulfing(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
