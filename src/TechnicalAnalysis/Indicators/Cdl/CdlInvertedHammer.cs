// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlInvertedHammer.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlInvertedHammer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlInvertedHammer CdlInvertedHammer(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleInvertedHammer(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlInvertedHammer(retCode, begIdx, nbElement, ints);
        }

        public static CdlInvertedHammer CdlInvertedHammer(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlInvertedHammer(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public class CdlInvertedHammer : IndicatorBase
    {
        public CdlInvertedHammer(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
