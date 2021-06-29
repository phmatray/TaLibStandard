// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ppo.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Ppo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Ppo Ppo(int startIdx, int endIdx, double[] real, int fastPeriod, int slowPeriod, MAType maType)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Ppo(
                startIdx,
                endIdx,
                real,
                fastPeriod,
                slowPeriod,
                maType,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new Ppo(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Ppo Ppo(int startIdx, int endIdx, double[] real)
            => Ppo(startIdx, endIdx, real, 12, 26, MAType.Sma);

        public static Ppo Ppo(int startIdx, int endIdx, float[] real, int fastPeriod, int slowPeriod, MAType maType)
            => Ppo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);
        
        public static Ppo Ppo(int startIdx, int endIdx, float[] real)
            => Ppo(startIdx, endIdx, real, 12, 26, MAType.Sma);
    }

    public class Ppo : IndicatorBase
    {
        public Ppo(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
