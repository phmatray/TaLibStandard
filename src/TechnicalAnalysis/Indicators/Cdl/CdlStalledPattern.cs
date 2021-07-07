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
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleStalledPattern(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlStalledPattern(retCode, begIdx, nbElement, ints);
        }

        public static CdlStalledPattern CdlStalledPattern(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlStalledPattern(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlStalledPattern : IndicatorBase
    {
        public CdlStalledPattern(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
