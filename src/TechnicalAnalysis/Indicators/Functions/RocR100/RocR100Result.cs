using TechnicalAnalysis.Common;

namespace TechnicalAnalysis;

public record RocR100Result : IndicatorBase
{
    public RocR100Result(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}
