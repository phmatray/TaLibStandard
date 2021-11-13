using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionT3;

public record T3Result : IndicatorBase
{
    public T3Result(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}