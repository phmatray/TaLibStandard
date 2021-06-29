// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlXSideGap3Methods.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlXSideGap3Methods.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
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

            RetCode retCode = TACore.CdlXSideGap3Methods(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            
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
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
