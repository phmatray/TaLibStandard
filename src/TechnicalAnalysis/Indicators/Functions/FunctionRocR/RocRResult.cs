using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionRocR;

public record RocRResult : IndicatorBase
{
    public RocRResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}