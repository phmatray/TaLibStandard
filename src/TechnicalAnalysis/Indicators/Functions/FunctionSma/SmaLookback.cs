using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionSma;

/// <summary>
/// Simple Moving Average Lookback
/// </summary>
public record SmaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="SmaLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public SmaLookback(int optInTimePeriod = 30)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod - 1;
        }
    }
}
