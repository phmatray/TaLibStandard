// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlClosingMarubozu.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlClosingMarubozu.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlClosingMarubozu CdlClosingMarubozu(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleClosingMarubozu(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlClosingMarubozu(retCode, begIdx, nbElement, ints);
        }

        public static CdlClosingMarubozu CdlClosingMarubozu(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlClosingMarubozu(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlClosingMarubozu : IndicatorBase
    {
        public CdlClosingMarubozu(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
