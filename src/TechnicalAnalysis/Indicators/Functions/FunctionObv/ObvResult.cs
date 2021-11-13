using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionObv;

public record ObvResult : IndicatorBase
{
    public ObvResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}