// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RocP.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines RocP.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static RocP RocP(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.RocP(startIdx, endIdx, real, timePeriod, ref outBegIdx, ref outNBElement, outReal);
            
            return new RocP(retCode, outBegIdx, outNBElement, outReal);
        }
        
        public static RocP RocP(int startIdx, int endIdx, double[] real)
            => RocP(startIdx, endIdx, real, 10);

        public static RocP RocP(int startIdx, int endIdx, float[] real, int timePeriod)
            => RocP(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static RocP RocP(int startIdx, int endIdx, float[] real)
            => RocP(startIdx, endIdx, real, 10);
    }

    public class RocP : IndicatorBase
    {
        public RocP(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
