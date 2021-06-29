// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtDcPhase.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines HtDcPhase.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtDcPhase HtDcPhase(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtDcPhase(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new HtDcPhase(retCode, outBegIdx, outNBElement, outReal);
        }

        public static HtDcPhase HtDcPhase(int startIdx, int endIdx, float[] real)
            => HtDcPhase(startIdx, endIdx, real.ToDouble());
    }

    public class HtDcPhase : IndicatorBase
    {
        public HtDcPhase(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
