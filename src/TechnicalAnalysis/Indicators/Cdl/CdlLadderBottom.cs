// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlLadderBottom.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlLadderBottom.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlLadderBottom CdlLadderBottom(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleLadderBottom(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlLadderBottom(retCode, begIdx, nbElement, ints);
        }

        public static CdlLadderBottom CdlLadderBottom(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlLadderBottom(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public class CdlLadderBottom : IndicatorBase
    {
        public CdlLadderBottom(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
