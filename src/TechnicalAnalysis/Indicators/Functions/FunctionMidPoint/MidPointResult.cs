using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMidPoint;

public record MidPointResult : IndicatorBase
{
    public MidPointResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}