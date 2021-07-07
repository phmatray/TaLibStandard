// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlMorningDojiStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlMorningDojiStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlMorningDojiStar CdlMorningDojiStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleMorningDojiStar(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlMorningDojiStar(retCode, begIdx, nbElement, ints);
        }

        public static CdlMorningDojiStar CdlMorningDojiStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlMorningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
        }

        public static CdlMorningDojiStar CdlMorningDojiStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlMorningDojiStar(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CdlMorningDojiStar CdlMorningDojiStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlMorningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
        }
    }

    public record CdlMorningDojiStar : IndicatorBase
    {
        public CdlMorningDojiStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
