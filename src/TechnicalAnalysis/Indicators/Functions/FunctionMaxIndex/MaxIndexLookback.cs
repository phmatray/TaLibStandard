using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMaxIndex;

/// <summary>
/// Index of highest value over a specified period Lookback
/// </summary>
public record MaxIndexLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MaxIndexLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MaxIndexLookback(int optInTimePeriod = 30)
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
