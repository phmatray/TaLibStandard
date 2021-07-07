// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlLongLeggedDoji.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlLongLeggedDoji.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlLongLeggedDoji CdlLongLeggedDoji(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleLongLeggedDoji(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlLongLeggedDoji(retCode, begIdx, nbElement, ints);
        }

        public static CdlLongLeggedDoji CdlLongLeggedDoji(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlLongLeggedDoji(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlLongLeggedDoji : IndicatorBase
    {
        public CdlLongLeggedDoji(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
