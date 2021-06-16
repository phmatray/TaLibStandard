// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MovingAverageVariablePeriod.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MovingAverageVariablePeriod.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MovingAverageVariablePeriod MovingAverageVariablePeriod(
            int startIdx,
            int endIdx,
            double[] real,
            double[] periods,
            int minPeriod = 2,
            int maxPeriod = 30,
            MAType mAType = MAType.Sma)
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
                mAType,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new MovingAverageVariablePeriod(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MovingAverageVariablePeriod MovingAverageVariablePeriod(
            int startIdx,
            int endIdx,
            float[] real,
            float[] periods,
            int minPeriod = 2,
            int maxPeriod = 30,
            MAType mAType = MAType.Sma)
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
                mAType,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new MovingAverageVariablePeriod(retCode, outBegIdx, outNBElement, outReal);
        }
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