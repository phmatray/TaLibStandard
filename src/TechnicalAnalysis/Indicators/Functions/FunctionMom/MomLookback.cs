using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMom;

/// <summary>
/// Momentum Lookback
/// </summary>
public record MomLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MomLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public MomLookback(int optInTimePeriod = 10)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod;
        }
    }
}
