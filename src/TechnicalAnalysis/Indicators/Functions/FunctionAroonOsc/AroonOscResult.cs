using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAroonOsc;

public record AroonOscResult : IndicatorBase
{
    public AroonOscResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}