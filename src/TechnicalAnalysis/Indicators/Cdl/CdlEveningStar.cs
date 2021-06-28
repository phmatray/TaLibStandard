// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlEveningStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlEveningStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static CdlEveningStar CdlEveningStar(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close,
            double penetration = 0.3)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.CdlEveningStar(
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
            return new CdlEveningStar(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlEveningStar CdlEveningStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close,
            double penetration = 0.3)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.CdlEveningStar(
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
            return new CdlEveningStar(retCode, outBegIdx, outNBElement, outInteger);
        }
    }

    public class CdlEveningStar : IndicatorBase
    {
        public CdlEveningStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
