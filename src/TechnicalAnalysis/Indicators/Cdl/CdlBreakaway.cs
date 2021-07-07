// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlBreakaway.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlBreakaway.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlBreakaway CdlBreakaway(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleBreakaway(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlBreakaway(retCode, begIdx, nbElement, ints);
        }

        public static CdlBreakaway CdlBreakaway(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlBreakaway(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlBreakaway : IndicatorBase
    {
        public CdlBreakaway(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
