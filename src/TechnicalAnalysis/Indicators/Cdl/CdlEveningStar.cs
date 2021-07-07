// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlEveningStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlEveningStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlEveningStar CdlEveningStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleEveningStar(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlEveningStar(retCode, begIdx, nbElement, ints);
        }

        public static CdlEveningStar CdlEveningStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlEveningStar(startIdx, endIdx, open, high, low, close, 0.3);
        }

        public static CdlEveningStar CdlEveningStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlEveningStar(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CdlEveningStar CdlEveningStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlEveningStar(startIdx, endIdx, open, high, low, close, 0.3);
        }
    }

    public record CdlEveningStar : IndicatorBase
    {
        public CdlEveningStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
