using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMfi;

public record MfiResult : IndicatorBase
{
    public MfiResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}