// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlDarkCloudCover.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlDarkCloudCover.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close,
            double penetration = 0.5)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            int[] outInteger = new int[endIdx - startIdx + 1];

            var retCode = TACore.CdlDarkCloudCover(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                penetration,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new CdlDarkCloudCover(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlDarkCloudCover CdlDarkCloudCover(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close,
            double penetration = 0.5)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            int[] outInteger = new int[endIdx - startIdx + 1];

            var retCode = TACore.CdlDarkCloudCover(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                penetration,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new CdlDarkCloudCover(retCode, outBegIdx, outNBElement, outInteger);
        }
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