// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LinearReg.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines LinearReg.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static LinearReg LinearReg(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.LinearReg(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new LinearReg(retCode, outBegIdx, outNBElement, outReal);
        }
        
        public static LinearReg LinearReg(int startIdx, int endIdx, double[] real)
            => LinearReg(startIdx, endIdx, real, 14);

        public static LinearReg LinearReg(int startIdx, int endIdx, float[] real, int timePeriod)
            => LinearReg(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static LinearReg LinearReg(int startIdx, int endIdx, float[] real)
            => LinearReg(startIdx, endIdx, real, 14);
    }

    public record LinearReg : IndicatorBase
    {
        public LinearReg(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
