// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlTakuri.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlTakuri.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlTakuri CdlTakuri(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleTakuri(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlTakuri(retCode, begIdx, nbElement, ints);
        }

        public static CdlTakuri CdlTakuri(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlTakuri(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlTakuri : IndicatorBase
    {
        public CdlTakuri(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
