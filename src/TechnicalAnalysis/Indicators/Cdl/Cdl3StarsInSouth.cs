// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3StarsInSouth.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3StarsInSouth.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl3StarsInSouth Cdl3StarsInSouth(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new Candle3StarsInSouth(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new Cdl3StarsInSouth(retCode, begIdx, nbElement, ints);
        }

        public static Cdl3StarsInSouth Cdl3StarsInSouth(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl3StarsInSouth(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record Cdl3StarsInSouth : IndicatorBase
    {
        public Cdl3StarsInSouth(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
