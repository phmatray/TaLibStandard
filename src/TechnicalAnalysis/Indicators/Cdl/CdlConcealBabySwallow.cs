// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlConcealBabySwallow.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlConcealBabySwallow.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlConcealBabySwallow CdlConcealBabySwallow(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleConcealBabySwallow(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlConcealBabySwallow(retCode, begIdx, nbElement, ints);
        }

        public static CdlConcealBabySwallow CdlConcealBabySwallow(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlConcealBabySwallow(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlConcealBabySwallow : IndicatorBase
    {
        public CdlConcealBabySwallow(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
