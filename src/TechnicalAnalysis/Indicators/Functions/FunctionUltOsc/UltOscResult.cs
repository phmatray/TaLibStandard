using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionUltOsc;

public record UltOscResult : IndicatorBase
{
    public UltOscResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}