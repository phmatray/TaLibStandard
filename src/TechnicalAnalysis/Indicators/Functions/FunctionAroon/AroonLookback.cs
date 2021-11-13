using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAroon;

/// <summary>
/// Aroon Lookback
/// </summary>
public record AroonLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="AroonLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public AroonLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod;
        }
    }
}
