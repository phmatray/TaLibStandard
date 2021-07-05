// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlHangingMan.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlHangingMan.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlHangingMan CdlHangingMan(
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

            CandleHangingMan candle = new (open, high, low, close);
            RetCode retCode = candle.CdlHangingMan(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlHangingMan(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlHangingMan CdlHangingMan(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlHangingMan(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlHangingMan : IndicatorBase
    {
        public CdlHangingMan(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
