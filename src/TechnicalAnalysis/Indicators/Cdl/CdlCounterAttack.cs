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
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleCounterAttack(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlCounterAttack(retCode, begIdx, nbElement, ints);
        }

        public static CdlCounterAttack CdlCounterAttack(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlCounterAttack(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlCounterAttack : IndicatorBase
    {
        public CdlCounterAttack(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
