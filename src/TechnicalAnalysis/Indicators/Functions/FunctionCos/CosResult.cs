using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionCos;

public record CosResult : IndicatorBase
{
    public CosResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}