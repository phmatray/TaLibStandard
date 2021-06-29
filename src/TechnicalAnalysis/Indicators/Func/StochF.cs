// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StochF.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines StochF.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static StochF StochF(
            int startIdx,
            int endIdx,
            double[] high,
            double[] low,
            double[] close,
            int fastK_Period,
            int fastD_Period,
            MAType fastD_MAType)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outFastK = new double[endIdx - startIdx + 1];
            double[] outFastD = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.StochF(
                startIdx,
                endIdx,
                high,
                low,
                close,
                fastK_Period,
                fastD_Period,
                fastD_MAType,
                ref outBegIdx,
                ref outNBElement,
                outFastK,
                outFastD);
            
            return new StochF(retCode, outBegIdx, outNBElement, outFastK, outFastD);
        }

        public static StochF StochF(int startIdx, int endIdx, double[] high, double[] low, double[] close)
            => StochF(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma);

        public static StochF StochF(
            int startIdx,
            int endIdx,
            float[] high,
            float[] low,
            float[] close,
            int fastK_Period,
            int fastD_Period,
            MAType fastD_MAType)
            => StochF(
                startIdx,
                endIdx,
                high.ToDouble(),
                low.ToDouble(),
                close.ToDouble(),
                fastK_Period,
                fastD_Period,
                fastD_MAType);
        
        public static StochF StochF(int startIdx, int endIdx, float[] high, float[] low, float[] close)
            => StochF(startIdx, endIdx, high, low, close, 5, 3, MAType.Sma);
    }

    public class StochF : IndicatorBase
    {
        public StochF(RetCode retCode, int begIdx, int nbElement, double[] fastK, double[] fastD)
            : base(retCode, begIdx, nbElement)
        {
            this.FastK = fastK;
            this.FastD = fastD;
        }

        public double[] FastD { get; }

        public double[] FastK { get; }
    }
}
