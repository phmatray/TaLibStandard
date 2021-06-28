// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Log10.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Log10.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Log10 Log10(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Log10(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Log10(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Log10 Log10(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Log10(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Log10(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Log10 : IndicatorBase
    {
        public Log10(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}