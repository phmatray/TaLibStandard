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
    public static partial class TAMath
    {
        public static Apo Apo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, MAType maType)
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
                ref outReal);
            
            return new Apo(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Apo Apo(int startIdx, int endIdx, double[] real)
            => Apo(startIdx, endIdx, real, 12, 26, MAType.Sma);

        public static Apo Apo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, MAType maType)
            => Apo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);

        public static Apo Apo(int startIdx, int endIdx, float[] real)
            => Apo(startIdx, endIdx, real, 12, 26, MAType.Sma);
    }

    public class Apo : IndicatorBase
    {
        public Apo(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
