// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlGravestoneDoji.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlGravestoneDoji.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlGravestoneDoji CdlGravestoneDoji(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleGravestoneDoji(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlGravestoneDoji(retCode, begIdx, nbElement, ints);
        }

        public static CdlGravestoneDoji CdlGravestoneDoji(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlGravestoneDoji(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlGravestoneDoji : IndicatorBase
    {
        public CdlGravestoneDoji(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
