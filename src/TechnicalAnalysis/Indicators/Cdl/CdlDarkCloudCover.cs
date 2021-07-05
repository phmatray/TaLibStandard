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
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleDarkCloudCover(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlDarkCloudCover(retCode, begIdx, nbElement, ints);
        }

        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlDarkCloudCover(startIdx, endIdx, open, high, low, close, 0.5);
        }

        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlDarkCloudCover(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlDarkCloudCover(startIdx, endIdx, open, high, low, close, 0.5);
        }
    }

    public class CdlDarkCloudCover : IndicatorBase
    {
        public CdlDarkCloudCover(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
