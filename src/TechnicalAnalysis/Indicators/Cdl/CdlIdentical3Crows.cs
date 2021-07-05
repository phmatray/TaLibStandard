// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlIdentical3Crows.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlIdentical3Crows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlIdentical3Crows CdlIdentical3Crows(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleIdentical3Crows(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlIdentical3Crows(retCode, begIdx, nbElement, ints);
        }

        public static CdlIdentical3Crows CdlIdentical3Crows(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlIdentical3Crows(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public class CdlIdentical3Crows : IndicatorBase
    {
        public CdlIdentical3Crows(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
