// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Kama.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines the TechnicalAnalysis type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Kama Kama(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Kama(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Kama(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Kama Kama(int startIdx, int endIdx, float[] real, int timePeriod = 30)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Kama(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            return new Kama(retCode, outBegIdx, outNBElement, outReal);
        }
    }

    public class Kama : IndicatorBase
    {
        public Kama(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}