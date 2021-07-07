// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlBeltHold.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlBeltHold.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlBeltHold CdlBeltHold(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleBeltHold(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlBeltHold(retCode, begIdx, nbElement, ints);
        }

        public static CdlBeltHold CdlBeltHold(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlBeltHold(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlBeltHold : IndicatorBase
    {
        public CdlBeltHold(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
