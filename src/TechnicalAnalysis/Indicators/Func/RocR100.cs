// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RocR100.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines RocR100.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static RocR100 RocR100(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.RocR100(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            
            return new RocR100(retCode, outBegIdx, outNBElement, outReal);
        }

        public static RocR100 RocR100(int startIdx, int endIdx, double[] real)
            => RocR100(startIdx, endIdx, real, 10);

        public static RocR100 RocR100(int startIdx, int endIdx, float[] real, int timePeriod)
            => RocR100(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static RocR100 RocR100(int startIdx, int endIdx, float[] real)
            => RocR100(startIdx, endIdx, real, 10);
    }

    public class RocR100 : IndicatorBase
    {
        public RocR100(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
