using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record Log10Result : IndicatorBase
{
    public Log10Result(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}
