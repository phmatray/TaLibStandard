using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionKama;

public record KamaResult : IndicatorBase
{
    public KamaResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}