// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sma.cs" company="GLPM">
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
        public static Sma Sma(int startIdx, int endIdx, double[] real, int timePeriod = 30)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Sma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            
            return new Sma(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Sma Sma(int startIdx, int endIdx, float[] real, int timePeriod = 30)
            => Sma(startIdx, endIdx, real.ToDouble(), timePeriod);
    }

    public class Sma : IndicatorBase
    {
        public Sma(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
