// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Correl.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Correl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Correl Correl(int startIdx, int endIdx, double[] real0, double[] real1, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Correl(
                startIdx,
                endIdx,
                real0,
                real1,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new Correl(retCode, outBegIdx, outNBElement, outReal);
        }
        
        public static Correl Correl(int startIdx, int endIdx, double[] real0, double[] real1)
            => Correl(startIdx, endIdx, real0, real1, 30);

        public static Correl Correl(int startIdx, int endIdx, float[] real0, float[] real1, int timePeriod)
            => Correl(startIdx, endIdx, real0.ToDouble(), real1.ToDouble(), timePeriod);
        
        public static Correl Correl(int startIdx, int endIdx, float[] real0, float[] real1)
            => Correl(startIdx, endIdx, real0, real1, 30);
    }

    public class Correl : IndicatorBase
    {
        public Correl(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
