// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BollingerBands.cs" company="GLPM">
//   Copyright (c) GLPM. All rights reserved.
// </copyright>
// <summary>
//   Defines BollingerBands.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TechnicalAnalysis
{
    public partial class TAMath
    {
        public static BollingerBands BollingerBands(
            int startIdx,
            int endIdx,
            double[] real,
            int timePeriod = 5,
            double nbDevUp = 2.0,
            double nbDevDn = 2.0,
            MAType maType = MAType.Sma)
        {
            int outBegIdx = default;
            int outNBElement = default;
            double[] outRealUpperBand = new double[endIdx - startIdx + 1];
            double[] outRealMiddleBand = new double[endIdx - startIdx + 1];
            double[] outRealLowerBand = new double[endIdx - startIdx + 1];

            RetCode retCode = TACore.BollingerBands(
                startIdx,
                endIdx,
                real,
                timePeriod,
                nbDevUp,
                nbDevDn,
                maType,
                ref outBegIdx,
                ref outNBElement,
                outRealUpperBand,
                outRealMiddleBand,
                outRealLowerBand);
            
            return new BollingerBands(
                retCode,
                outBegIdx,
                outNBElement,
                outRealUpperBand,
                outRealMiddleBand,
                outRealLowerBand);
        }

        public static BollingerBands BollingerBands(
            int startIdx,
            int endIdx,
            float[] real,
            int timePeriod = 5,
            double nbDevUp = 2.0,
            double nbDevDn = 2.0,
            MAType maType = MAType.Sma)
            => BollingerBands(startIdx, endIdx, real.ToDouble(), timePeriod, nbDevUp, nbDevDn, maType);
    }

    public class BollingerBands : IndicatorBase
    {
        public BollingerBands(
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
