// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3BlackCrows.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3BlackCrows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Cdl3BlackCrows Cdl3BlackCrows(
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

            var retCode = TACore.Cdl3BlackCrows(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new Cdl3BlackCrows(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static Cdl3BlackCrows Cdl3BlackCrows(
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

            var retCode = TACore.Cdl3BlackCrows(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            return new Cdl3BlackCrows(retCode, outBegIdx, outNBElement, outInteger);
        }
    }

    public class Cdl3BlackCrows : IndicatorBase
    {
        public Cdl3BlackCrows(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}