using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMinusDI;

public record MinusDIResult : IndicatorBase
{
    public MinusDIResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}