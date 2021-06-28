// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StochRsi.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines the TechnicalAnalysis type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static StochRsi StochRsi(
            int startIdx,
            int endIdx,
            double[] real,
            int timePeriod = 14,
            int fastKPeriod = 5,
            int fastDPeriod = 3,
            MAType fastDMAType = MAType.Sma)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outFastK = new double[endIdx - startIdx + 1];
            double[] outFastD = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.StochRsi(
                startIdx,
                endIdx,
                real,
                timePeriod,
                fastKPeriod,
                fastDPeriod,
                fastDMAType,
                ref outBegIdx,
                ref outNBElement,
                outFastK,
                outFastD);
            return new StochRsi(retCode, outBegIdx, outNBElement, outFastK, outFastD);
        }

        public static StochRsi StochRsi(
            int startIdx,
            int endIdx,
            float[] real,
            int timePeriod = 14,
            int fastKPeriod = 5,
            int fastDPeriod = 3,
            MAType fastDMAType = MAType.Sma)
        {
            int outBegIdx = 0;
            int outNBElement = 0;
            double[] outFastK = new double[endIdx - startIdx + 1];
            double[] outFastD = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.StochRsi(
                startIdx,
                endIdx,
                real,
                timePeriod,
                fastKPeriod,
                fastDPeriod,
                fastDMAType,
                ref outBegIdx,
                ref outNBElement,
                outFastK,
                outFastD);
            return new StochRsi(retCode, outBegIdx, outNBElement, outFastK, outFastD);
        }
    }

    public class StochRsi : IndicatorBase
    {
        public StochRsi(RetCode retCode, int begIdx, int nbElement, double[] fastK, double[] fastD)
            : base(retCode, begIdx, nbElement)
        {
            this.FastK = fastK;
            this.FastD = fastD;
        }

        public double[] FastD { get; }

        public double[] FastK { get; }
    }
}