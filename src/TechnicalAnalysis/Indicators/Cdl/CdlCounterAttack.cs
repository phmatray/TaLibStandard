// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlCounterAttack.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlCounterAttack.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlCounterAttack CdlCounterAttack(
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

            CandleCounterAttack candle = new (open, high, low, close);
            RetCode retCode = candle.CdlCounterAttack(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlCounterAttack(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlCounterAttack CdlCounterAttack(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlCounterAttack(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlCounterAttack : IndicatorBase
    {
        public CdlCounterAttack(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
