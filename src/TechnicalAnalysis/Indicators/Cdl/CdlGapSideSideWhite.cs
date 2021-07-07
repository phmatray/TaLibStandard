// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlGapSideSideWhite.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlGapSideSideWhite.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlGapSideSideWhite CdlGapSideSideWhite(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleGapSideSideWhite(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlGapSideSideWhite(retCode, begIdx, nbElement, ints);
        }

        public static CdlGapSideSideWhite CdlGapSideSideWhite(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlGapSideSideWhite(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlGapSideSideWhite : IndicatorBase
    {
        public CdlGapSideSideWhite(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
