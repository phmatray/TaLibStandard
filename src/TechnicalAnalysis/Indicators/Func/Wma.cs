// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Wma.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Wma.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Wma Wma(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Wma(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            return new Wma(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Wma Wma(int startIdx, int endIdx, double[] real)
            => Wma(startIdx, endIdx, real, 30);

        public static Wma Wma(int startIdx, int endIdx, float[] real, int timePeriod)
            => Wma(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Wma Wma(int startIdx, int endIdx, float[] real)
            => Wma(startIdx, endIdx, real, 30);
    }

    public class Wma : IndicatorBase
    {
        public Wma(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
