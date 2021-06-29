// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SarExt.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines SarExt.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static SarExt SarExt(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double startValue = 0.0,
            double offsetOnReverse = 0.0,
            double accelerationInitLong = 0.02,
            double accelerationLong = 0.02,
            double accelerationMaxLong = 0.2,
            double accelerationInitShort = 0.02,
            double accelerationShort = 0.02,
            double accelerationMaxShort = 0.2)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.SarExt(
                startIdx,
                endIdx,
                high,
                low,
                startValue,
                offsetOnReverse,
                accelerationInitLong,
                accelerationLong,
                accelerationMaxLong,
                accelerationInitShort,
                accelerationShort,
                accelerationMaxShort,
                ref outBegIdx,
                ref outNBElement,
                outReal);
            
            return new SarExt(retCode, outBegIdx, outNBElement, outReal);
        }

        public static SarExt SarExt(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            double startValue = 0.0,
            double offsetOnReverse = 0.0,
            double accelerationInitLong = 0.02,
            double accelerationLong = 0.02,
            double accelerationMaxLong = 0.2,
            double accelerationInitShort = 0.02,
            double accelerationShort = 0.02,
            double accelerationMaxShort = 0.2)
            => SarExt(
                startIdx,
                endIdx,
                high.ToDouble(),
                low.ToDouble(),
                startValue,
                offsetOnReverse,
                accelerationInitLong,
                accelerationLong,
                accelerationMaxLong,
                accelerationInitShort,
                accelerationShort,
                accelerationMaxShort);
    }

    public class SarExt : IndicatorBase
    {
        public SarExt(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            this.Real = real;
        }

        public double[] Real { get; }
    }
}
