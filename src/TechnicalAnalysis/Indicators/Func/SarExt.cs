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
    public static partial class TAMath
    {
        public static SarExt SarExt(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double startValue,
            double offsetOnReverse,
            double accelerationInitLong,
            double accelerationLong,
            double accelerationMaxLong,
            double accelerationInitShort,
            double accelerationShort,
            double accelerationMaxShort)
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

        public static SarExt SarExt(int startIdx, int endIdx, double[] high, double[] low)
            => SarExt(startIdx, endIdx, high, low, 0.0, 0.0, 0.02, 0.02, 0.2, 0.02, 0.02, 0.2);

        public static SarExt SarExt(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            double startValue,
            double offsetOnReverse,
            double accelerationInitLong,
            double accelerationLong,
            double accelerationMaxLong,
            double accelerationInitShort,
            double accelerationShort,
            double accelerationMaxShort)
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
        
        public static SarExt SarExt(int startIdx, int endIdx, float[] high, float[] low)
            => SarExt(startIdx, endIdx, high, low, 0.0, 0.0, 0.02, 0.02, 0.2, 0.02, 0.02, 0.2);
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
