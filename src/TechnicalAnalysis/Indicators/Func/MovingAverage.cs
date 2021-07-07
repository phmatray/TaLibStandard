// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovingAverage.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MovingAverage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using TechnicalAnalysis.Abstractions;

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MovingAverage MovingAverage(
            int startIdx,
            int endIdx,
            double[] real,
            int timePeriod,
            MAType maType)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MovingAverage(
                startIdx,
                endIdx,
                real,
                timePeriod,
                maType,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);

            return new MovingAverage(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MovingAverage MovingAverage(int startIdx, int endIdx, double[] real)
            => MovingAverage(startIdx, endIdx, real, 30, MAType.Sma);

        public static MovingAverage MovingAverage(int startIdx, int endIdx, float[] real, int timePeriod, MAType maType)
            => MovingAverage(startIdx, endIdx, real.ToDouble(), timePeriod, maType);

        public static MovingAverage MovingAverage(int startIdx, int endIdx, float[] real)
            => MovingAverage(startIdx, endIdx, real, 30, MAType.Sma);
    }

    public record MovingAverage : IndicatorBase
    {
        public MovingAverage(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
