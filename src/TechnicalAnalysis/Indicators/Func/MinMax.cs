// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MinMax.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MinMax.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MinMax MinMax(int startIdx, int endIdx, double[] real, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outMin = new double[endIdx - startIdx + 1];
            double[] outMax = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MinMax(
                startIdx,
                endIdx,
                real,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outMin,
                ref outMax);
            
            return new MinMax(retCode, outBegIdx, outNBElement, outMin, outMax);
        }

        public static MinMax MinMax(int startIdx, int endIdx, double[] real)
            => MinMax(startIdx, endIdx, real, 30);

        public static MinMax MinMax(int startIdx, int endIdx, float[] real, int timePeriod)
            => MinMax(startIdx, endIdx, real.ToDouble(), timePeriod);
        
        public static MinMax MinMax(int startIdx, int endIdx, float[] real)
            => MinMax(startIdx, endIdx, real, 30);
    }

    public class MinMax : IndicatorBase
    {
        public MinMax(RetCode retCode, int begIdx, int nbElement, double[] min, double[] max)
            : base(retCode, begIdx, nbElement)
        {
            Min = min;
            Max = max;
        }

        public double[] Max { get; }

        public double[] Min { get; }
    }
}
