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
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            CandleXSideGap3Methods candle = new (open, high, low, close);
            RetCode retCode = candle.CdlXSideGap3Methods(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlXSideGap3Methods(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlXSideGap3Methods CdlXSideGap3Methods(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlXSideGap3Methods(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble());
    }

    public class CdlXSideGap3Methods : IndicatorBase
    {
        public CdlXSideGap3Methods(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
