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
    public static partial class TAMath
    {
        public static BollingerBands BollingerBands(
            int startIdx,
            int endIdx,
            double[] real,
            int timePeriod,
            double nbDevUp,
            double nbDevDn,
            MAType maType)
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
                ref outRealUpperBand,
                ref outRealMiddleBand,
                ref outRealLowerBand);
            
            return new BollingerBands(
                retCode,
                outBegIdx,
                outNBElement,
                outRealUpperBand,
                outRealMiddleBand,
                outRealLowerBand);
        }
        
        public static BollingerBands BollingerBands(int startIdx, int endIdx, double[] real)
            => BollingerBands(startIdx, endIdx, real, 5, 2.0, 2.0, MAType.Sma);

        public static BollingerBands BollingerBands(
            int startIdx,
            int endIdx,
            float[] real,
            int timePeriod,
            double nbDevUp,
            double nbDevDn,
            MAType maType)
            => BollingerBands(startIdx, endIdx, real.ToDouble(), timePeriod, nbDevUp, nbDevDn, maType);
        
        public static BollingerBands BollingerBands(int startIdx, int endIdx, float[] real)
            => BollingerBands(startIdx, endIdx, real, 5, 2.0, 2.0, MAType.Sma);
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
            RealUpperBand = realUpperBand;
            RealMiddleBand = realMiddleBand;
            RealLowerBand = realLowerBand;
        }

        public double[] RealLowerBand { get; }

        public double[] RealMiddleBand { get; }

        public double[] RealUpperBand { get; }
    }
}
