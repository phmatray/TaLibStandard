// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlKickingByLength.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlKickingByLength.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlKickingByLength CdlKickingByLength(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleKickingByLength(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlKickingByLength(retCode, begIdx, nbElement, ints);
        }

        public static CdlKickingByLength CdlKickingByLength(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlKickingByLength(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlKickingByLength : IndicatorBase
    {
        public CdlKickingByLength(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
