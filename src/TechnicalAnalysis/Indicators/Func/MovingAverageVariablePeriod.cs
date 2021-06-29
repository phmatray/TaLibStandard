// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovingAverageVariablePeriod.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MovingAverageVariablePeriod.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MovingAverageVariablePeriod MovingAverageVariablePeriod(
            int startIdx,
            int endIdx,
            double[] real,
            double[] periods,
            int minPeriod,
            int maxPeriod,
            MAType maType)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MovingAverageVariablePeriod(
                startIdx,
                endIdx,
                real,
                periods,
                minPeriod,
                maxPeriod,
                maType,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new MovingAverageVariablePeriod(retCode, outBegIdx, outNBElement, outReal);
        }
        
        public static MovingAverageVariablePeriod MovingAverageVariablePeriod(
            int startIdx,
            int endIdx,
            double[] real,
            double[] periods)
            => MovingAverageVariablePeriod(startIdx, endIdx, real, periods, 2, 30, MAType.Sma);

        public static MovingAverageVariablePeriod MovingAverageVariablePeriod(
            int startIdx,
            int endIdx,
            float[] real,
            float[] periods,
            int minPeriod,
            int maxPeriod,
            MAType maType)
            => MovingAverageVariablePeriod(
                startIdx,
                endIdx,
                real.ToDouble(),
                periods.ToDouble(),
                minPeriod,
                maxPeriod,
                maType);
        
        public static MovingAverageVariablePeriod MovingAverageVariablePeriod(
            int startIdx,
            int endIdx,
            float[] real,
            float[] periods)
            => MovingAverageVariablePeriod(startIdx, endIdx, real, periods, 2, 30, MAType.Sma);
    }

    public class MovingAverageVariablePeriod : IndicatorBase
    {
        public MovingAverageVariablePeriod(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
