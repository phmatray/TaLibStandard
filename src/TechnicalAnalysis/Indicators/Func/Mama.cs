// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Mama.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Mama.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Mama Mama(
            int startIdx,
            int endIdx,
            double[] real,
            double fastLimit = 0.5,
            double slowLimit = 0.05)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outMAMA = new double[endIdx - startIdx + 1];
            double[] outFAMA = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Mama(
                startIdx,
                endIdx,
                real,
                fastLimit,
                slowLimit,
                ref outBegIdx,
                ref outNBElement,
                outMAMA,
                outFAMA);
            
            return new Mama(retCode, outBegIdx, outNBElement, outMAMA, outFAMA);
        }

        public static Mama Mama(
            int startIdx,
            int endIdx,
            float[] real,
            double fastLimit = 0.5,
            double slowLimit = 0.05)
            => Mama(startIdx, endIdx, real.ToDouble(), fastLimit, slowLimit);
    }

    public class Mama : IndicatorBase
    {
        public Mama(RetCode retCode, int begIdx, int nbElement, double[] mama, double[] fama)
            : base(retCode, begIdx, nbElement)
        {
            this.MAMA = mama;
            this.FAMA = fama;
        }

        public double[] FAMA { get; }

        public double[] MAMA { get; }
    }
}
