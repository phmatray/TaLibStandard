// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinMax.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MinMax.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MinMax MinMax(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outMin = new double[endIdx - startIdx + 1];
            double[] outMax = new double[endIdx - startIdx + 1];

            var retCode = TACore.MinMax(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outMin,
                outMax);
            return new MinMax(retCode, outBegIdx, outNBElement, outMin, outMax);
        }

        public static MinMax MinMax(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outMin = new double[endIdx - startIdx + 1];
            double[] outMax = new double[endIdx - startIdx + 1];

            var retCode = TACore.MinMax(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                outMin,
                outMax);
            return new MinMax(retCode, outBegIdx, outNBElement, outMin, outMax);
        }
    }

    public class MinMax : IndicatorBase
    {
        public MinMax(RetCode retCode, int begIdx, int nbElement, double[] min, double[] max)
            : base(retCode, begIdx, nbElement)
        {
            this.Min = min;
            this.Max = max;
        }

        public double[] Max { get; }

        public double[] Min { get; }
    }
}