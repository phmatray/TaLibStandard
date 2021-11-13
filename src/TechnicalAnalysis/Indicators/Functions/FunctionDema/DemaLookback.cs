using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionEma;

namespace TechnicalAnalysis.Functions.FunctionDema;

/// <summary>
/// Double Exponential Moving Average Lookback
/// </summary>
public record DemaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="DemaLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public DemaLookback(int optInTimePeriod = 30)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = new EmaLookback(optInTimePeriod).Result * 2;
        }
    }
}
