// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlHammer.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlHammer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlHammer CdlHammer(
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

            CandleHammer candle = new (open, high, low, close);
            RetCode retCode = candle.CdlHammer(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlHammer(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlHammer CdlHammer(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlHammer(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlHammer : IndicatorBase
    {
        public CdlHammer(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
