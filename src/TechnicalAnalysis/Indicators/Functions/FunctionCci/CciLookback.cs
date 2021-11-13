using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionCci;

/// <summary>
/// Commodity Channel Index Lookback
/// </summary>
public record CciLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="CciLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public CciLookback(int optInTimePeriod = 14)
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
