// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlXSideGap3Methods.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlXSideGap3Methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlXSideGap3Methods CdlXSideGap3Methods(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleXSideGap3Methods(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlXSideGap3Methods(retCode, begIdx, nbElement, ints);
        }

        public static CdlXSideGap3Methods CdlXSideGap3Methods(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlXSideGap3Methods(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlXSideGap3Methods : IndicatorBase
    {
        public CdlXSideGap3Methods(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
