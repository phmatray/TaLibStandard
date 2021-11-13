using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionNatr;

public record NatrResult : IndicatorBase
{
    public NatrResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}