// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlSeparatingLines.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlSeparatingLines.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlSeparatingLines CdlSeparatingLines(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleSeparatingLines(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlSeparatingLines(retCode, begIdx, nbElement, ints);
        }

        public static CdlSeparatingLines CdlSeparatingLines(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlSeparatingLines(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlSeparatingLines : IndicatorBase
    {
        public CdlSeparatingLines(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
