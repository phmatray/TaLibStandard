using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMinMax;

/// <summary>
/// Lowest and highest values over a specified period Lookback
/// </summary>
public record MinMaxLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MinMaxLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MinMaxLookback(int optInTimePeriod = 30)
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
