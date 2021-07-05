// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlHighWave.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlHighWave.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlHighWave CdlHighWave(
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

            CandleHighWave candle = new (open, high, low, close);
            RetCode retCode = candle.CdlHighWave(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlHighWave(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlHighWave CdlHighWave(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlHighWave(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlHighWave : IndicatorBase
    {
        public CdlHighWave(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
