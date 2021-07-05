// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlInNeck.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlInNeck.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlInNeck CdlInNeck(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleInNeck(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlInNeck(retCode, begIdx, nbElement, ints);
        }

        public static CdlInNeck CdlInNeck(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlInNeck(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public class CdlInNeck : IndicatorBase
    {
        public CdlInNeck(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
