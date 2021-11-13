using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAdx;

/// <summary>
/// Average Directional Movement Index Lookback
/// </summary>
public record AdxLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="AdxLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public AdxLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod * 2 + (int)TACore.Globals.unstablePeriod[0] - 1;
        }
    }
}
