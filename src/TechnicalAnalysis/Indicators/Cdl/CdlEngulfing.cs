// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlEngulfing.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlEngulfing.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlEngulfing CdlEngulfing(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleEngulfing(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlEngulfing(retCode, begIdx, nbElement, ints);
        }

        public static CdlEngulfing CdlEngulfing(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlEngulfing(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlEngulfing : IndicatorBase
    {
        public CdlEngulfing(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
