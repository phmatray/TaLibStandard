using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMovingAverageVariablePeriod;

public record MovingAverageVariablePeriodResult : IndicatorBase
{
    public MovingAverageVariablePeriodResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}