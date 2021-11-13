using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMin;

/// <summary>
/// Lowest value over a specified period Lookback
/// </summary>
public record MinLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MinLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MinLookback(int optInTimePeriod = 30)
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
