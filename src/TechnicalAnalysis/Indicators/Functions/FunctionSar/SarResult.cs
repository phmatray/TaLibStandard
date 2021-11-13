using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionSar;

public record SarResult : IndicatorBase
{
    public SarResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}