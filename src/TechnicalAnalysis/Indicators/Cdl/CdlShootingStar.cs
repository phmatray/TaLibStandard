// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlShootingStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlShootingStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlShootingStar CdlShootingStar(
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

            CandleShootingStar candle = new (open, high, low, close);
            RetCode retCode = candle.CdlShootingStar(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlShootingStar(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlShootingStar CdlShootingStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlShootingStar(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlShootingStar : IndicatorBase
    {
        public CdlShootingStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
