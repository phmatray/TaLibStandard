using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMinusDI;

/// <summary>
/// Minus Directional Indicator Lookback
/// </summary>
public record MinusDILookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MinusDILookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public MinusDILookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod + (int)TACore.Globals.UnstablePeriods[FuncUnstId.MinusDI];
        }
    }
}
