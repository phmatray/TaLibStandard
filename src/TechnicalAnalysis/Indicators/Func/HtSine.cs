// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HtSine.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines HtSine.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static HtSine HtSine(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outSine = new double[endIdx - startIdx + 1];
            double[] outLeadSine = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.HtSine(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outSine, outLeadSine);
            
            return new HtSine(retCode, outBegIdx, outNBElement, outSine, outLeadSine);
        }

        public static HtSine HtSine(int startIdx, int endIdx, float[] real)
            => HtSine(startIdx, endIdx, real.ToDouble());
    }

    public class HtSine : IndicatorBase
    {
        public HtSine(RetCode retCode, int begIdx, int nbElement, double[] sine, double[] leadSine)
            : base(retCode, begIdx, nbElement)
        {
            this.Sine = sine;
            this.LeadSine = leadSine;
        }

        public double[] LeadSine { get; }

        public double[] Sine { get; }
    }
}
