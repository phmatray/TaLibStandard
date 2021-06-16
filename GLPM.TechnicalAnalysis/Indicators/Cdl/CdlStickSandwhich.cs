// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlStickSandwhich.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlStickSandwhich.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static CdlStickSandwhich CdlStickSandwhich(
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

            var retCode = TACore.CdlStickSandwhich(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new CdlStickSandwhich(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlStickSandwhich CdlStickSandwhich(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            var retCode = TACore.CdlStickSandwhich(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new CdlStickSandwhich(retCode, outBegIdx, outNBElement, outInteger);
        }
    }

    public class CdlStickSandwhich : IndicatorBase
    {
        public CdlStickSandwhich(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}