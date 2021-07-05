// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlUpsideGap2Crows.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlUpsideGap2Crows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlUpsideGap2Crows CdlUpsideGap2Crows(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleUpsideGap2Crows(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlUpsideGap2Crows(retCode, begIdx, nbElement, ints);
        }

        public static CdlUpsideGap2Crows CdlUpsideGap2Crows(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlUpsideGap2Crows(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public class CdlUpsideGap2Crows : IndicatorBase
    {
        public CdlUpsideGap2Crows(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
