using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionHtDcPeriod;

public record HtDcPeriodResult : IndicatorBase
{
    public HtDcPeriodResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}