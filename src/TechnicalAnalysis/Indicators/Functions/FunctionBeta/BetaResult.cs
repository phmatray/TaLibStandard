using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionBeta;

public record BetaResult : IndicatorBase
{
    public BetaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}
