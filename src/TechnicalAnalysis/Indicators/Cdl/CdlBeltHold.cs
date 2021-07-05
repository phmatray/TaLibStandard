// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlBeltHold.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlBeltHold.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlBeltHold CdlBeltHold(
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

            CandleBeltHold candle = new (open, high, low, close);
            RetCode retCode = candle.CdlBeltHold(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlBeltHold(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlBeltHold CdlBeltHold(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlBeltHold(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlBeltHold : IndicatorBase
    {
        public CdlBeltHold(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
