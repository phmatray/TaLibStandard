using TechnicalAnalysis.Common;

// ReSharper disable once CheckNamespace
namespace TechnicalAnalysis
{
    public static partial class TAMath
    {
        public static BollingerBandsResult BollingerBands(
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
            
            return new(
                retCode,
                outBegIdx,
                outNBElement,
                outRealUpperBand,
                outRealMiddleBand,
                outRealLowerBand);
        }
        
        public static BollingerBandsResult BollingerBands(int startIdx, int endIdx, double[] real)
            => BollingerBands(startIdx, endIdx, real, 5, 2.0, 2.0, MAType.Sma);

        public static BollingerBandsResult BollingerBands(
            int startIdx,
            int endIdx,
            float[] real,
            int timePeriod,
            double nbDevUp,
            double nbDevDn,
            MAType maType)
            => BollingerBands(startIdx, endIdx, real.ToDouble(), timePeriod, nbDevUp, nbDevDn, maType);
        
        public static BollingerBandsResult BollingerBands(int startIdx, int endIdx, float[] real)
            => BollingerBands(startIdx, endIdx, real, 5, 2.0, 2.0, MAType.Sma);
    }
}
