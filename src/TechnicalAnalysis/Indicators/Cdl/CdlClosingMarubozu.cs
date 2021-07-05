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

            CandleClosingMarubozu candle = new (open, high, low, close);
            RetCode retCode = candle.CdlClosingMarubozu(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlClosingMarubozu(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlClosingMarubozu CdlClosingMarubozu(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlClosingMarubozu(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlClosingMarubozu : IndicatorBase
    {
        public CdlClosingMarubozu(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
