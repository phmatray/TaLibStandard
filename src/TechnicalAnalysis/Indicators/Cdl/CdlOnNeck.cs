// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlOnNeck.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlOnNeck.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlOnNeck CdlOnNeck(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleOnNeck(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlOnNeck(retCode, begIdx, nbElement, ints);
        }

        public static CdlOnNeck CdlOnNeck(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlOnNeck(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlOnNeck : IndicatorBase
    {
        public CdlOnNeck(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
