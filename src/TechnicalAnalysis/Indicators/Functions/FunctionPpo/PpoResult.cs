using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionPpo;

public record PpoResult : IndicatorBase
{
    public PpoResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}