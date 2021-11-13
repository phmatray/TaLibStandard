using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMama;

public record MamaResult : IndicatorBase
{
    public MamaResult(RetCode retCode, int begIdx, int nbElement, double[] mama, double[] fama)
        : base(retCode, begIdx, nbElement)
    {
        MAMA = mama;
        FAMA = fama;
    }

    public double[] FAMA { get; }

    public double[] MAMA { get; }
}