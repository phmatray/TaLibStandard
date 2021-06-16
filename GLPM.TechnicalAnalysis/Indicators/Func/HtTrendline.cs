// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtTrendline.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines HtTrendline.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static HtTrendline HtTrendline(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.HtTrendline(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new HtTrendline(retCode, outBegIdx, outNBElement, outReal);
        }

        public static HtTrendline HtTrendline(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.HtTrendline(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new HtTrendline(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class HtTrendline : IndicatorBase
    {
        public HtTrendline(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}