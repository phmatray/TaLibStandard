// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlDarkCloudCover.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlDarkCloudCover.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close,
            double penetration)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            CandleDarkCloudCover candle = new (open, high, low, close);
            RetCode retCode = candle.CdlDarkCloudCover(
                startIdx,
                endIdx,
                penetration,
                ref outBegIdx,
                ref outNBElement,
                ref outInteger);
            
            return new CdlDarkCloudCover(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
            => CdlDarkCloudCover(startIdx, endIdx, open, high, low, close, 0.5);

        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close,
            double penetration)
            => CdlDarkCloudCover(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                penetration);
        
        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlDarkCloudCover(startIdx, endIdx, open, high, low, close, 0.5);
    }

    public class CdlDarkCloudCover : IndicatorBase
    {
        public CdlDarkCloudCover(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
