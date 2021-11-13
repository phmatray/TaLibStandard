using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAtr;

public record AtrResult : IndicatorBase
{
    public AtrResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}