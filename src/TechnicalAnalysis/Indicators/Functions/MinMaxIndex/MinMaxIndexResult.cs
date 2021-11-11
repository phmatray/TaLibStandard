using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record MinMaxIndexResult : IndicatorBase
{
    public MinMaxIndexResult(RetCode retCode, int begIdx, int nbElement, int[] minIdx, int[] maxIdx)
        : base(retCode, begIdx, nbElement)
    {
        MinIdx = minIdx;
        MaxIdx = maxIdx;
    }

    public int[] MaxIdx { get; }

    public int[] MinIdx { get; }
}