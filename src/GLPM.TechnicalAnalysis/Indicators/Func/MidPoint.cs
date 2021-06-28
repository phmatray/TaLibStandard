// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MidPoint.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MidPoint.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MidPoint MidPoint(int startIdx, int endIdx, double[] real, int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MidPoint(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new MidPoint(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MidPoint MidPoint(int startIdx, int endIdx, float[] real, int timePeriod = 14)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MidPoint(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new MidPoint(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class MidPoint : IndicatorBase
    {
        public MidPoint(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}