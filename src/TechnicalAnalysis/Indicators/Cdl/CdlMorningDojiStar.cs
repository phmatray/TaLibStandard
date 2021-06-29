// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlMorningDojiStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlMorningDojiStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlMorningDojiStar CdlMorningDojiStar(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close,
            double penetration)
        {
            int outBegIdx = default;
            int outNBElement = default;
            int[] outInteger = new int[endIdx - startIdx + 1];

            RetCode retCode = TACore.CdlMorningDojiStar(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                penetration,
                ref outBegIdx,
                ref outNBElement,
                outInteger);
            
            return new CdlMorningDojiStar(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlMorningDojiStar CdlMorningDojiStar(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
            => CdlMorningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);

        public static CdlMorningDojiStar CdlMorningDojiStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close,
            double penetration)
            => CdlMorningDojiStar(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                penetration);
        
        public static CdlMorningDojiStar CdlMorningDojiStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlMorningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
    }

    public class CdlMorningDojiStar : IndicatorBase
    {
        public CdlMorningDojiStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
