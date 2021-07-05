// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Variance.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Variance.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Variance Variance(int startIdx, int endIdx, double[] real, int timePeriod, double nbDev)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Variance(
                startIdx,
                endIdx,
                real,
                timePeriod,
                nbDev,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new Variance(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Variance Variance(int startIdx, int endIdx, double[] real)
            => Variance(startIdx, endIdx, real, 5, 1.0);

        public static Variance Variance(int startIdx, int endIdx, float[] real, int timePeriod, double nbDev)
            => Variance(startIdx, endIdx, real.ToDouble(), timePeriod, nbDev);
        
        public static Variance Variance(int startIdx, int endIdx, float[] real)
            => Variance(startIdx, endIdx, real, 5, 1.0);
    }

    public class Variance : IndicatorBase
    {
        public Variance(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
