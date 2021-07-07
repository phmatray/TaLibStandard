// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RocR.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines RocR.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static RocR RocR(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.RocR(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, ref outReal);
            
            return new RocR(retCode, outBegIdx, outNBElement, outReal);
        }

        public static RocR RocR(int startIdx, int endIdx, double[] real)
            => RocR(startIdx, endIdx, real, 10);

        public static RocR RocR(int startIdx, int endIdx, float[] real, int timePeriod)
            => RocR(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static RocR RocR(int startIdx, int endIdx, float[] real)
            => RocR(startIdx, endIdx, real, 10);
    }

    public record RocR : IndicatorBase
    {
        public RocR(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
