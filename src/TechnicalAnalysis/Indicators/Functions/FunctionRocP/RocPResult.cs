using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionRocP;

public record RocPResult : IndicatorBase
{
    public RocPResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}