using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionDema;
using TechnicalAnalysis.Functions.FunctionEma;
using TechnicalAnalysis.Functions.FunctionKama;
using TechnicalAnalysis.Functions.FunctionMama;
using TechnicalAnalysis.Functions.FunctionSma;
using TechnicalAnalysis.Functions.FunctionT3;
using TechnicalAnalysis.Functions.FunctionTema;
using TechnicalAnalysis.Functions.FunctionTrima;
using TechnicalAnalysis.Functions.FunctionWma;

namespace TechnicalAnalysis.Functions.FunctionMovingAverage;

/// <summary>
/// Moving average Lookback
/// </summary>
public record MovingAverageLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MovingAverageLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    /// <param name="optInMAType">Type of Moving Average</param>
    public MovingAverageLookback(
        int optInTimePeriod = 30,
        MAType optInMAType = MAType.Sma)
    {
        if (optInTimePeriod <= 1)
        {
            Result = 0;
        }
        else
        {
            Result = optInMAType switch
            {
                MAType.Sma => new SmaLookback(optInTimePeriod).Result,
                MAType.Ema => new EmaLookback(optInTimePeriod).Result,
                MAType.Wma => new WmaLookback(optInTimePeriod).Result,
                MAType.Dema => new DemaLookback(optInTimePeriod).Result,
                MAType.Tema => new TemaLookback(optInTimePeriod).Result,
                MAType.Trima => new TrimaLookback(optInTimePeriod).Result,
                MAType.Kama => new KamaLookback(optInTimePeriod).Result,
                MAType.Mama => new MamaLookback().Result,
                MAType.T3 => new T3Lookback(optInTimePeriod).Result,
                _ => 0
            };
        }
    }
}
