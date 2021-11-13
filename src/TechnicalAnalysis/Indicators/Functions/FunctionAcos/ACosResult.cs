using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAcos;

public record ACosResult : IndicatorBase
{
    public ACosResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}
