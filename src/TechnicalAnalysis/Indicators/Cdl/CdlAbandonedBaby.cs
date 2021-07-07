// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlAbandonedBaby.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlAbandonedBaby.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlAbandonedBaby CdlAbandonedBaby(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleAbandonedBaby(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlAbandonedBaby(retCode, begIdx, nbElement, ints);
        }
        
        public static CdlAbandonedBaby CdlAbandonedBaby(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlAbandonedBaby(startIdx, endIdx, open, high, low, close, 0.3);
        }

        public static CdlAbandonedBaby CdlAbandonedBaby(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlAbandonedBaby(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CdlAbandonedBaby CdlAbandonedBaby(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlAbandonedBaby(startIdx, endIdx, open, high, low, close, 0.3);
        }
    }

    public record CdlAbandonedBaby : IndicatorBase
    {
        public CdlAbandonedBaby(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
