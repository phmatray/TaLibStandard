// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlStickSandwich.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlStickSandwich.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlStickSandwich CdlStickSandwich(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleStickSandwich(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlStickSandwich(retCode, begIdx, nbElement, ints);
        }

        public static CdlStickSandwich CdlStickSandwich(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlStickSandwich(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlStickSandwich : IndicatorBase
    {
        public CdlStickSandwich(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
