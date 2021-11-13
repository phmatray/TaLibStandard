using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionCorrel;

/// <summary>
/// Pearson's Correlation Coefficient (r) Lookback
/// </summary>
public record CorrelLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="CorrelLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public CorrelLookback(int optInTimePeriod = 30)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod - 1;
        }
    }
}
