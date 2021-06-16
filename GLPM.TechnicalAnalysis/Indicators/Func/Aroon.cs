// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Aroon.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Aroon.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Aroon Aroon(int startIdx, int endIdx, double[] high, double[] low, int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outAroonDown = new double[endIdx - startIdx + 1];
            double[] outAroonUp = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Aroon(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outAroonDown,
                outAroonUp);
            return new Aroon(retCode, outBegIdx, outNBElement, outAroonDown, outAroonUp);
        }

        public static Aroon Aroon(int startIdx, int endIdx, float[] high, float[] low, int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outAroonDown = new double[endIdx - startIdx + 1];
            double[] outAroonUp = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Aroon(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outAroonDown,
                outAroonUp);
            return new Aroon(retCode, outBegIdx, outNBElement, outAroonDown, outAroonUp);
        }
    }

    public class Aroon : IndicatorBase
    {
        public Aroon(RetCode retCode, int begIdx, int nbElement, double[] aroonDown, double[] aroonUp)
            : base(retCode, begIdx, nbElement)
        {
            this.AroonDown = aroonDown;
            this.AroonUp = aroonUp;
        }

        public double[] AroonDown { get; }

        public double[] AroonUp { get; }
    }
}