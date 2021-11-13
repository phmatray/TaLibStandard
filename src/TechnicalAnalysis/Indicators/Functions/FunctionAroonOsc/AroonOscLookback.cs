using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionAroonOsc;

/// <summary>
/// Aroon Oscillator Lookback
/// </summary>
public record AroonOscLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="AroonOscLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public AroonOscLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod;
        }
    }
}
