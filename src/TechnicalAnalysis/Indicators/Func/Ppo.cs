﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Ppo.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Ppo.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Ppo Ppo(
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

            RetCode retCode = TACore.Ppo(
                startIdx,
                endIdx,
                real,
                fastPeriod,
                slowPeriod,
                maType,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new Ppo(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Ppo Ppo(
            int startIdx,
            int endIdx,
            float[] real,
            int fastPeriod = 12,
            int slowPeriod = 26,
            MAType maType = MAType.Sma)
            => Ppo(startIdx, endIdx, real.ToDouble(), fastPeriod, slowPeriod, maType);
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
