// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlUpsideGap2Crows.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlUpsideGap2Crows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlUpsideGap2Crows CdlUpsideGap2Crows(
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

            RetCode retCode = TACore.CdlUpsideGap2Crows(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                ref outInteger);
            
            return new CdlUpsideGap2Crows(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlUpsideGap2Crows CdlUpsideGap2Crows(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlUpsideGap2Crows(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlUpsideGap2Crows : IndicatorBase
    {
        public CdlUpsideGap2Crows(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
