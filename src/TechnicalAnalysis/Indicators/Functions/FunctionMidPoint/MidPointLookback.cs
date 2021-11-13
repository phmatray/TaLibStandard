using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMidPoint;

/// <summary>
/// MidPoint over period Lookback
/// </summary>
public record MidPointLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MidPointLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MidPointLookback(int optInTimePeriod = 14)
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
