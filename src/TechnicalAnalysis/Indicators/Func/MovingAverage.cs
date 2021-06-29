// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovingAverage.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MovingAverage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MovingAverage MovingAverage(
            int startIdx,
            int endIdx,
            double[] real,
            int timePeriod = 30,
            MAType maType = MAType.Sma)
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
                outReal);
            
            return new MovingAverage(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MovingAverage MovingAverage(
            int startIdx,
            int endIdx,
            float[] real,
            int timePeriod = 30,
            MAType maType = MAType.Sma)
            => MovingAverage(startIdx, endIdx, real.ToDouble(), timePeriod, maType);
    }

    public class MovingAverage : IndicatorBase
    {
        public MovingAverage(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
