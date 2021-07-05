// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlUnique3River.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlUnique3River.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlUnique3River CdlUnique3River(
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

            CandleUnique3River candle = new (open, high, low, close);
            RetCode retCode = candle.CdlUnique3River(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlUnique3River(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlUnique3River CdlUnique3River(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlUnique3River(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlUnique3River : IndicatorBase
    {
        public CdlUnique3River(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
