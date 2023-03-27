using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record MacdFixResult : IndicatorBase
{
    public MacdFixResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] macd,
        double[] macdSignal,
        double[] macdHist)
        : base(retCode, begIdx, nbElement)
    {
        MACD = macd;
        MACDSignal = macdSignal;
        MACDHist = macdHist;
    }

    public double[] MACD { get; }

    public double[] MACDHist { get; }

    public double[] MACDSignal { get; }
}
