using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionStoch;

public record StochResult : IndicatorBase
{
    public StochResult(RetCode retCode, int begIdx, int nbElement, double[] slowK, double[] slowD)
        : base(retCode, begIdx, nbElement)
    {
        SlowK = slowK;
        SlowD = slowD;
    }

    public double[] SlowD { get; }

    public double[] SlowK { get; }
}