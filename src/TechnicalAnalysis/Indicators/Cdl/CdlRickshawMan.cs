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
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleRickshawMan(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlRickshawMan(retCode, begIdx, nbElement, ints);
        }

        public static CdlRickshawMan CdlRickshawMan(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlRickshawMan(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
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
