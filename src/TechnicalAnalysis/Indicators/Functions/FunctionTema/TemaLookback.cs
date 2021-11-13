using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionEma;

namespace TechnicalAnalysis.Functions.FunctionTema;

/// <summary>
/// Triple Exponential Moving Average Lookback
/// </summary>
public record TemaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="TemaLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public TemaLookback(int optInTimePeriod = 30)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            // Get lookback for one EMA.
            Result = new EmaLookback(optInTimePeriod).Result * 3;
        }
    }
}
