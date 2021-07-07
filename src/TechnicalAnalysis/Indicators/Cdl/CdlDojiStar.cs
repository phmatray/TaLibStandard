// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlDojiStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlDojiStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;
using TechnicalAnalysis.Candle;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlDojiStar CdlDojiStar(
            int startIdx, int endIdx, double[] open, double[] high, double[] low, double[] close)
        {
            RetCode retCode = new CandleDojiStar(open, high, low, close)
                .TryCompute(startIdx, endIdx, out int begIdx, out int nbElement, out int[] ints);
            
            return new CdlDojiStar(retCode, begIdx, nbElement, ints);
        }

        public static CdlDojiStar CdlDojiStar(
            int startIdx, int endIdx, float[] open, float[] high, float[] low, float[] close)
        {
            return CdlDojiStar(startIdx, endIdx,
                open.ToDouble(), high.ToDouble(), low.ToDouble(), close.ToDouble());
        }
    }

    public record CdlDojiStar : IndicatorBase
    {
        public CdlDojiStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            Integer = integer;
        }

        public int[] Integer { get; }
    }
}
