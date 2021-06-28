// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Acos.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines the TechnicalAnalysis type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Acos Acos(int startIdx, int endIdx, double[] real)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Acos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Acos(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Acos Acos(int startIdx, int endIdx, float[] real)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Acos(startIdx, endIdx, real, ref outBegIdx, ref outNBElement, outReal);
            return new Acos(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Acos : IndicatorBase
    {
        public Acos(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
