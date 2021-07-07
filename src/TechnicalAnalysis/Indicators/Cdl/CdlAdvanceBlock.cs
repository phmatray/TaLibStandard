// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlAdvanceBlock.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlAdvanceBlock.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlAdvanceBlock CdlAdvanceBlock(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleAdvanceBlock(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlAdvanceBlock(retCode, begIdx, nbElement, ints);
        }

        public static CdlAdvanceBlock CdlAdvanceBlock(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlAdvanceBlock(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlAdvanceBlock : IndicatorBase
    {
        public CdlAdvanceBlock(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
