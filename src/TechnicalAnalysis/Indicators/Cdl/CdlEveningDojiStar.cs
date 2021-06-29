// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CdlEveningDojiStar.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines CdlEveningDojiStar.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static CdlEveningDojiStar CdlEveningDojiStar(
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

            RetCode retCode = TACore.CdlEveningDojiStar(
                startIdx,
                endIdx,
                open,
                high,
                low,
                close,
                penetration,
                ref outBegIdx,
                ref outNBElement,
                ref outInteger);
            
            return new CdlEveningDojiStar(retCode, outBegIdx, outNBElement, outInteger);
        }

        public static CdlEveningDojiStar CdlEveningDojiStar(
            int startIdx,
            int endIdx,
            double[] open,
            double[] high,
            double[] low,
            double[] close)
            => CdlEveningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);

        public static CdlEveningDojiStar CdlEveningDojiStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close,
            double penetration)
            => CdlEveningDojiStar(
                startIdx,
                endIdx,
                open.ToDouble(),
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                penetration);
        
        public static CdlEveningDojiStar CdlEveningDojiStar(
            int startIdx,
            int endIdx,
            float[] open,
            float[] high,
            float[] low,
            float[] close)
            => CdlEveningDojiStar(startIdx, endIdx, open, high, low, close, 0.3);
    }

    public class CdlEveningDojiStar : IndicatorBase
    {
        public CdlEveningDojiStar(RetCode retCode, int begIdx, int nbElement, int[] integer)
            : base(retCode, begIdx, nbElement)
        {
            this.Integer = integer;
        }

        public int[] Integer { get; }
    }
}
