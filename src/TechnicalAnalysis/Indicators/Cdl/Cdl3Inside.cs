// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3Inside.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3Inside.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl3Inside Cdl3Inside(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new Candle3Inside(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new Cdl3Inside(retCode, begIdx, nbElement, ints);
        }

        public static Cdl3Inside Cdl3Inside(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl3Inside(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record Cdl3Inside : IndicatorBase
    {
        public Cdl3Inside(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
