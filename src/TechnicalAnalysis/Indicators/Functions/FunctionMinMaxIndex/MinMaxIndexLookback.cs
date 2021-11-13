using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMinMaxIndex;

/// <summary>
/// Indexes of lowest and highest values over a specified period Lookback
/// </summary>
public record MinMaxIndexLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MinMaxIndexLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MinMaxIndexLookback(int optInTimePeriod = 30)
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
