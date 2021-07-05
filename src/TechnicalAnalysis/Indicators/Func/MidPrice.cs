// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MidPrice.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines MidPrice.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static MidPrice MidPrice(int startIdx, int endIdx, double[] high, double[] low, int timePeriod)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outReal = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.MidPrice(
                startIdx,
                endIdx,
                high,
                low,
                timePeriod,
                ref outBegIdx,
                ref outNBElement,
                ref outReal);
            
            return new MidPrice(retCode, outBegIdx, outNBElement, outReal);
        }

        public static MidPrice MidPrice(int startIdx, int endIdx, double[] high, double[] low)
            => MidPrice(startIdx, endIdx, high, low, 14);

        public static MidPrice MidPrice(int startIdx, int endIdx, float[] high, float[] low, int timePeriod)
            => MidPrice(startIdx, endIdx, high.ToDouble(), low.ToDouble(), timePeriod);
        
        public static MidPrice MidPrice(int startIdx, int endIdx, float[] high, float[] low)
            => MidPrice(startIdx, endIdx, high, low, 14);
    }

    public class MidPrice : IndicatorBase
    {
        public MidPrice(RetCode retCode, int begIdx, int nbElement, double[] real)
            : base(retCode, begIdx, nbElement)
        {
            Real = real;
        }

        public double[] Real { get; }
    }
}
