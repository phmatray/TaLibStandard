using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionAdx;

namespace TechnicalAnalysis.Functions.FunctionAdxr;

/// <summary>
/// Average Directional Movement Index Rating Lookback
/// </summary>
public record AdxrLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="AdxrLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public AdxrLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod + new AdxLookback(optInTimePeriod).Result - 1;
        }
    }
}
