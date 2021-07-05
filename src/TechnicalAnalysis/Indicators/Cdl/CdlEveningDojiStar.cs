// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlEveningDojiStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlEveningDojiStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlEveningDojiStar CdlEveningDojiStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close, double penetration)
        {
            RetCode retCode = new CandleEveningDojiStar(open, high, low, close)
                .TryCompute(startIdx, endIdx, penetration, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlEveningDojiStar(retCode, begIdx, nbElement, ints);
        }

        public static CdlEveningDojiStar CdlEveningDojiStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            return CdlEveningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
        }

        public static CdlEveningDojiStar CdlEveningDojiStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close, double penetration)
        {
            return CdlEveningDojiStar(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble(), penetration);
        }

        public static CdlEveningDojiStar CdlEveningDojiStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlEveningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
        }
    }

    public class CdlEveningDojiStar : IndicatorBase
    {
        public CdlEveningDojiStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
