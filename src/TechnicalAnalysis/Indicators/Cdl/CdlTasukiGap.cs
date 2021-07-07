// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlTasukiGap.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlTasukiGap.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlTasukiGap CdlTasukiGap(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleTasukiGap(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlTasukiGap(retCode, begIdx, nbElement, ints);
        }

        public static CdlTasukiGap CdlTasukiGap(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlTasukiGap(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlTasukiGap : IndicatorBase
    {
        public CdlTasukiGap(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
