// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlEveningStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlEveningStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlEveningStar CdlEveningStar(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close,
            double penetration)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            CandleEveningStar candle = new (open, high, low, close);
            RetCode retCode = candle.CdlEveningStar(
                startIdx,
                endIdx,
                penetration,
                ref outBegIdx,
                ref outNBElement,
                ref outInteger);
            
            return new CdlEveningStar(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlEveningStar CdlEveningStar(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
            => CdlEveningStar(startIdx, endIdx, open, high, low, close, 0.3);

        public static CdlEveningStar CdlEveningStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close,
            double penetration)
            => CdlEveningStar(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                penetration);
        
        public static CdlEveningStar CdlEveningStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlEveningStar(startIdx, endIdx, open, high, low, close, 0.3);
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
