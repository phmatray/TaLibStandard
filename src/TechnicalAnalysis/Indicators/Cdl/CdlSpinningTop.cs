// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlSpinningTop.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlSpinningTop.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlSpinningTop CdlSpinningTop(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleSpinningTop(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlSpinningTop(retCode, begIdx, nbElement, ints);
        }

        public static CdlSpinningTop CdlSpinningTop(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlSpinningTop(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlSpinningTop : IndicatorBase
    {
        public CdlSpinningTop(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
