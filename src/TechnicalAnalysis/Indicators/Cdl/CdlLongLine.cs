// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlLongLine.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlLongLine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlLongLine CdlLongLine(
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

            CandleLongLine candle = new (open, high, low, close);
            RetCode retCode = candle.CdlLongLine(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlLongLine(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlLongLine CdlLongLine(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlLongLine(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlLongLine : IndicatorBase
    {
        public CdlLongLine(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
