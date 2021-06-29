// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlConcealBabysWall.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlConcealBabysWall.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        // TODO: rename to ConcealBabySwallow
        public static CdlConcealBabysWall CdlConcealBabysWall(
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

            RetCode retCode = TACore.CdlConcealBabysWall(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            
            return new CdlConcealBabysWall(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlConcealBabysWall CdlConcealBabysWall(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlConcealBabysWall(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble());
    }

    public class CdlConcealBabysWall : IndicatorBase
    {
        public CdlConcealBabysWall(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
