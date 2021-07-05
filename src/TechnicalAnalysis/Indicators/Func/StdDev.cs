// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StdDev.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines StdDev.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static StdDev StdDev(int startIdx, int endIdx, double[] real, int timePeriod, double nbDev)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.StdDev(
                startIdx,
                endIdx,
                real,
                timePeriod,
                nbDev,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new StdDev(retCode, outBegIdx, outNBElement, outReal);
        }

        public static StdDev StdDev(int startIdx, int endIdx, double[] real)
            => StdDev(startIdx, endIdx, real, 5, 1.0);

        public static StdDev StdDev(int startIdx, int endIdx, float[] real, int timePeriod, double nbDev)
            => StdDev(startIdx, endIdx, real.ToDouble(), timePeriod, nbDev);
        
        public static StdDev StdDev(int startIdx, int endIdx, float[] real)
            => StdDev(startIdx, endIdx, real, 5, 1.0);
    }

    public class StdDev : IndicatorBase
    {
        public StdDev(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
