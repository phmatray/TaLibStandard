using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record MacdResult : IndicatorBase
{
    public MacdResult(
        RetCode retCode,
        int begIdx,
        int nbElement,
        double[] macdValue,
        double[] macdSignal,
        double[] macdHist)
        : base(retCode, begIdx, nbElement)
    {
        MacdValue = macdValue;
        MacdSignal = macdSignal;
        MacdHist = macdHist;
    }

    public double[] MacdValue { get; }

    public double[] MacdHist { get; }

    public double[] MacdSignal { get; }
}