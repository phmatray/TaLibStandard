using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionSin;

public record SinResult : IndicatorBase
{
    public SinResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}