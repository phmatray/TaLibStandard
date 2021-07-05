// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlMorningStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlMorningStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlMorningStar CdlMorningStar(
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

            CandleMorningStar candle = new (open, high, low, close);
            RetCode retCode = candle.CdlMorningStar(
                startIdx,
                endIdx,
                penetration,
                ref outBegIdx,
                ref outNBElement,
                ref outInteger);
            
            return new CdlMorningStar(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlMorningStar CdlMorningStar(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
            => CdlMorningStar(startIdx, endIdx, open, high, low, close, 0.3);

        public static CdlMorningStar CdlMorningStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close,
            double penetration)
            => CdlMorningStar(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                penetration);
        
        public static CdlMorningStar CdlMorningStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlMorningStar(startIdx, endIdx, open, high, low, close, 0.3);
    }

    public class CdlMorningStar : IndicatorBase
    {
        public CdlMorningStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
