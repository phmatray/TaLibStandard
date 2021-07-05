// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlRickshawMan.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlRickshawMan.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlRickshawMan CdlRickshawMan(
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

            CandleRickshawMan candle = new (open, high, low, close);
            RetCode retCode = candle.CdlRickshawMan(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlRickshawMan(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlRickshawMan CdlRickshawMan(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlRickshawMan(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlRickshawMan : IndicatorBase
    {
        public CdlRickshawMan(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
