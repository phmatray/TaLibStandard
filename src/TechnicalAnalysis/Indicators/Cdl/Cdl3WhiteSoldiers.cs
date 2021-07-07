// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Cdl3WhiteSoldiers.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Cdl3WhiteSoldiers.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Cdl3WhiteSoldiers Cdl3WhiteSoldiers(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new Candle3WhiteSoldiers(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new Cdl3WhiteSoldiers(retCode, begIdx, nbElement, ints);
        }

        public static Cdl3WhiteSoldiers Cdl3WhiteSoldiers(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return Cdl3WhiteSoldiers(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record Cdl3WhiteSoldiers : IndicatorBase
    {
        public Cdl3WhiteSoldiers(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
