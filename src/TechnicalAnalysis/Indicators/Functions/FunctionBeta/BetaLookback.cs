using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionBeta;

/// <summary>
/// Beta Lookback
/// </summary>
public record BetaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="BetaLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public BetaLookback(int optInTimePeriod = 5)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod;
        }
    }
}
