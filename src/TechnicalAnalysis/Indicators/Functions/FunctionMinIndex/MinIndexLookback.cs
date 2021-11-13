using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMinIndex;

/// <summary>
/// Index of lowest value over a specified period Lookback
/// </summary>
public record MinIndexLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MinIndexLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MinIndexLookback(int optInTimePeriod = 30)
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
