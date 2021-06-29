// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Apo.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Apo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Apo Apo(
            int startIdx,
            int endIdx,
            double[] real,
            int fastPeriod = 12,
            int slowPeriod = 26,
            MAType maType = MAType.Sma)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Apo(
                startIdx,
                endIdx,
                real,
                fastPeriod,
                slowPeriod,
                maType,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new Apo(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Apo Apo(
            int startIdx,
            int endIdx,
            float[] real,
            int fastPeriod = 12,
            int slowPeriod = 26,
            MAType maType = MAType.Sma)
            => Apo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);
    }

    public class Apo : IndicatorBase
    {
        public Apo(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
