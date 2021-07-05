// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlIdentical3Crows.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlIdentical3Crows.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlIdentical3Crows CdlIdentical3Crows(
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

            CandleIdentical3Crows candle = new (open, high, low, close);
            RetCode retCode = candle.CdlIdentical3Crows(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlIdentical3Crows(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlIdentical3Crows CdlIdentical3Crows(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlIdentical3Crows(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlIdentical3Crows : IndicatorBase
    {
        public CdlIdentical3Crows(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
