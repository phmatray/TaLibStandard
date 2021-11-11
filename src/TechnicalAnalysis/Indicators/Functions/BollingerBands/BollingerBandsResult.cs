using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record BollingerBandsResult : IndicatorBase
{
    public BollingerBandsResult(
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