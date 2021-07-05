// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlSpinningTop.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlSpinningTop.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlSpinningTop CdlSpinningTop(
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

            CandleSpinningTop candle = new (open, high, low, close);
            RetCode retCode = candle.CdlSpinningTop(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlSpinningTop(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlSpinningTop CdlSpinningTop(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlSpinningTop(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlSpinningTop : IndicatorBase
    {
        public CdlSpinningTop(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
