using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionEma;

namespace TechnicalAnalysis.Functions.FunctionAdOsc;

/// <summary>
/// Chaikin A/D Oscillator Lookback
/// </summary>
public record AdOscLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="AdOscLookback"/> record.
    /// </summary>
    /// <param name="optInFastPeriod">Number of period for the fast MA (From 2 to 100000)</param>
    /// <param name="optInSlowPeriod">Number of period for the slow MA (From 2 to 100000)</param>
    public AdOscLookback(int optInFastPeriod = 3, int optInSlowPeriod = 10)
    {
        if (optInFastPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else if (optInSlowPeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            int slowestPeriod = optInFastPeriod < optInSlowPeriod
                ? optInSlowPeriod
                : optInFastPeriod;

            Result = new EmaLookback(slowestPeriod).Result;
        }
    }
}
