using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionTema;

public record TemaResult : IndicatorBase
{
    public TemaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}