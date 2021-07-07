// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlHighWave.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlHighWave.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlHighWave CdlHighWave(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleHighWave(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlHighWave(retCode, begIdx, nbElement, ints);
        }

        public static CdlHighWave CdlHighWave(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlHighWave(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlHighWave : IndicatorBase
    {
        public CdlHighWave(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
