// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlDojiStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlDojiStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlDojiStar CdlDojiStar(
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

            CandleDojiStar candle = new (open, high, low, close);
            RetCode retCode = candle.CdlDojiStar(startIdx, endIdx, ref outBegIdx, ref outNBElement, ref outInteger);
            
            return new CdlDojiStar(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlDojiStar CdlDojiStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlDojiStar(startIdx, endIdx, open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
    }

    public class CdlDojiStar : IndicatorBase
    {
        public CdlDojiStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
