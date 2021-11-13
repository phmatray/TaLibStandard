using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionWillR;

/// <summary>
/// Williams' %R Lookback
/// </summary>
public record WillRLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="WillRLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public WillRLookback(int optInTimePeriod = 14)
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
