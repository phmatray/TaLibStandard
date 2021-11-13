using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionHtTrendMode;

public record HtTrendModeResult : IndicatorBase
{
    public HtTrendModeResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}