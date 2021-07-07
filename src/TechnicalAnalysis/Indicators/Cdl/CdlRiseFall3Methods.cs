// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlRiseFall3Methods.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlRiseFall3Methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlRiseFall3Methods CdlRiseFall3Methods(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleRiseFall3Methods(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlRiseFall3Methods(retCode, begIdx, nbElement, ints);
        }

        public static CdlRiseFall3Methods CdlRiseFall3Methods(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlRiseFall3Methods(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlRiseFall3Methods : IndicatorBase
    {
        public CdlRiseFall3Methods(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
