// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MedPrice.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MedPrice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static MedPrice MedPrice(int startIdx, int endIdx, double[] high, double[] low)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.MedPrice(startIdx, endIdx, high, low, ref outBegIdx, ref outNBElement, outReal);
            return new MedPrice(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MedPrice MedPrice(int startIdx, int endIdx, float[] high, float[] low)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.MedPrice(startIdx, endIdx, high, low, ref outBegIdx, ref outNBElement, outReal);
            return new MedPrice(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class MedPrice : IndicatorBase
    {
        public MedPrice(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}