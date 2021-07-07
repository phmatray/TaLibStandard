// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlMorningStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlMorningStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlMorningStar CdlMorningStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleMorningStar(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlMorningStar(retCode, begIdx, nbElement, ints);
        }

        public static CdlMorningStar CdlMorningStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlMorningStar(startIdx, endIdx, open, high, low, close, 0.3);
        }

        public static CdlMorningStar CdlMorningStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlMorningStar(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CdlMorningStar CdlMorningStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlMorningStar(startIdx, endIdx, open, high, low, close, 0.3);
        }
    }

    public record CdlMorningStar : IndicatorBase
    {
        public CdlMorningStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
