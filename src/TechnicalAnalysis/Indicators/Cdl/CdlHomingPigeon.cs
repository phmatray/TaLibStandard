// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlHomingPigeon.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlHomingPigeon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlHomingPigeon CdlHomingPigeon(
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

            CandleHomingPigeon candle = new (open, high, low, close);
            RetCode retCode = candle.CdlHomingPigeon(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlHomingPigeon(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlHomingPigeon CdlHomingPigeon(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlHomingPigeon(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlHomingPigeon : IndicatorBase
    {
        public CdlHomingPigeon(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
