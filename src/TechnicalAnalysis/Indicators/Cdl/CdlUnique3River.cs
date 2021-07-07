// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlUnique3River.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlUnique3River.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlUnique3River CdlUnique3River(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleUnique3River(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlUnique3River(retCode, begIdx, nbElement, ints);
        }

        public static CdlUnique3River CdlUnique3River(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlUnique3River(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlUnique3River : IndicatorBase
    {
        public CdlUnique3River(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
