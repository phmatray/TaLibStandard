using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMinIndex;

public record MinIndexResult : IndicatorBase
{
    public MinIndexResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}