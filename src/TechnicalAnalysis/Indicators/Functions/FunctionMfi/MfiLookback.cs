using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMfi;

/// <summary>
/// Money Flow Index Lookback
/// </summary>
public record MfiLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MfiLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MfiLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod + (int)TACore.Globals.unstablePeriod[14];
        }
    }
}
