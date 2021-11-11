using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Candles.CandleHighWave;

public record CandleHighWaveResult : IndicatorBase
{
    public CandleHighWaveResult(RetCode retCode, int begIdx, int nbElement, int[] integer)
        : base(retCode, begIdx, nbElement)
    {
        Integer = integer;
    }

    public int[] Integer { get; }
}