// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Tema.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Tema.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static Tema Tema(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Tema(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new Tema(retCode, outBegIdx, outNBElement, outReal);
        }

        public static Tema Tema(int startIdx, int endIdx, double[] real)
            => Tema(startIdx, endIdx, real, 30);

        public static Tema Tema(int startIdx, int endIdx, float[] real, int timePeriod)
            => Tema(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static Tema Tema(int startIdx, int endIdx, float[] real)
            => Tema(startIdx, endIdx, real, 30);
    }

    public class Tema : IndicatorBase
    {
        public Tema(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
