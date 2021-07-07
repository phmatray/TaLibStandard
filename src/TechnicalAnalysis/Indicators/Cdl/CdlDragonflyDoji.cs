// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlDragonflyDoji.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlDragonflyDoji.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlDragonflyDoji CdlDragonflyDoji(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleDragonflyDoji(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlDragonflyDoji(retCode, begIdx, nbElement, ints);
        }

        public static CdlDragonflyDoji CdlDragonflyDoji(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlDragonflyDoji(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlDragonflyDoji : IndicatorBase
    {
        public CdlDragonflyDoji(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
