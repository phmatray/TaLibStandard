// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Bbands.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines Bbands.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GLPM.TechnicalAnalysis
{
    public partial class TAMath
    {
        public static Bbands Bbands(
            int startIdx,
            int endIdx,
            double[] real,
            int timePeriod = 5,
            double nbDevUp = 2.0,
            double nbDevDn = 2.0,
            MAType mAType = MAType.Sma)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outRealUpperBand = new double[endIdx - startIdx + 1];
            double[] outRealMiddleBand = new double[endIdx - startIdx + 1];
            double[] outRealLowerBand = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Bbands(
                startIdx,
                endIdx,
                real,
                timePeriod,
                nbDevUp,
                nbDevDn,
                mAType,
                ref outBegIdx,
                ref outNBElement,
                outRealUpperBand,
                outRealMiddleBand,
                outRealLowerBand);
            return new Bbands(
                retCode,
                outBegIdx,
                outNBElement,
                outRealUpperBand,
                outRealMiddleBand,
                outRealLowerBand);
        }

        public static Bbands Bbands(
            int startIdx,
            int endIdx,
            float[] real,
            int timePeriod = 5,
            double nbDevUp = 2.0,
            double nbDevDn = 2.0,
            MAType mAType = MAType.Sma)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outRealUpperBand = new double[endIdx - startIdx + 1];
            double[] outRealMiddleBand = new double[endIdx - startIdx + 1];
            double[] outRealLowerBand = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.Bbands(
                startIdx,
                endIdx,
                real,
                timePeriod,
                nbDevUp,
                nbDevDn,
                mAType,
                ref outBegIdx,
                ref outNBElement,
                outRealUpperBand,
                outRealMiddleBand,
                outRealLowerBand);
            return new Bbands(
                retCode,
                outBegIdx,
                outNBElement,
                outRealUpperBand,
                outRealMiddleBand,
                outRealLowerBand);
        }
    }

    public class Bbands : IndicatorBase
    {
        public Bbands(
            RetCode retCode,
            int begIdx,
            int nbElement,
            double[] realUpperBand,
            double[] realMiddleBand,
            double[] realLowerBand)
            : base(retCode, begIdx, nbElement)
        {
            this.RealUpperBand = realUpperBand;
            this.RealMiddleBand = realMiddleBand;
            this.RealLowerBand = realLowerBand;
        }

        public double[] RealLowerBand { get; }

        public double[] RealMiddleBand { get; }

        public double[] RealUpperBand { get; }
    }
}