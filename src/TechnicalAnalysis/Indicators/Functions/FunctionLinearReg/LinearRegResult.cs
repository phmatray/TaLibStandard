using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionLinearReg;

public record LinearRegResult : IndicatorBase
{
    public LinearRegResult(RetCode retCode, int begIdx, int nbElement, double[] real)
        : base(retCode, begIdx, nbElement)
    {
        Real = real;
    }

    public double[] Real { get; }
}