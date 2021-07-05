// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlKickingByLength.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlKickingByLength.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlKickingByLength CdlKickingByLength(
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

            CandleKickingByLength candle = new (open, high, low, close);
            RetCode retCode = candle.CdlKickingByLength(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlKickingByLength(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlKickingByLength CdlKickingByLength(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlKickingByLength(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlKickingByLength : IndicatorBase
    {
        public CdlKickingByLength(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
