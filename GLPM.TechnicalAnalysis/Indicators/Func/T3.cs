// --------------------------------------------------------------------------------------------------------------------
// <copyright file="T3.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines T3.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static T3 T3(int startIdx, int endIdx, double[] real, int timePeriod = 5, double vFactor = 0.7)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.T3(
                startIdx,
                endIdx,
                real,
                timePeriod,
                vFactor,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new T3(retCode, outBegIdx, outNBElement, outReal);
        }

        public static T3 T3(int startIdx, int endIdx, float[] real, int timePeriod = 5, double vFactor = 0.7)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.T3(
                startIdx,
                endIdx,
                real,
                timePeriod,
                vFactor,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            return new T3(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class T3 : IndicatorBase
    {
        public T3(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}