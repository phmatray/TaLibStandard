// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Add.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Add.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Add Add(int startIdx, int endIdx, double[] real0, double[] real1)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Add(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, outReal);
            return new Add(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Add Add(int startIdx, int endIdx, float[] real0, float[] real1)
        {
            int outBegIdx = default(int);
            int outNBElement = default(int);
            double[] outReal = new double[endIdx - startIdx + 1];

            var retCode = TACore.Add(startIdx, endIdx, real0, real1, ref outBegIdx, ref outNBElement, outReal);
            return new Add(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Add : IndicatorBase
    {
        public Add(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}