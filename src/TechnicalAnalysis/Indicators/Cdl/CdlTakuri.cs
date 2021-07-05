// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlTakuri.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlTakuri.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlTakuri CdlTakuri(
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

            CandleTakuri candle = new (open, high, low, close);
            RetCode retCode = candle.CdlTakuri(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlTakuri(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlTakuri CdlTakuri(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlTakuri(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlTakuri : IndicatorBase
    {
        public CdlTakuri(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
