// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlStalledPattern.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlStalledPattern.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlStalledPattern CdlStalledPattern(
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

            CandleStalledPattern candle = new (open, high, low, close);
            RetCode retCode = candle.CdlStalledPattern(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlStalledPattern(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlStalledPattern CdlStalledPattern(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlStalledPattern(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlStalledPattern : IndicatorBase
    {
        public CdlStalledPattern(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
