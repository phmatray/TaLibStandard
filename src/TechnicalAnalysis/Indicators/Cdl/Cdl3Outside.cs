// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3Outside.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3Outside.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl3Outside Cdl3Outside(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new Candle3Outside(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new Cdl3Outside(retCode, begIdx, nbElement, ints);
        }

        public static Cdl3Outside Cdl3Outside(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl3Outside(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record Cdl3Outside : IndicatorBase
    {
        public Cdl3Outside(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
