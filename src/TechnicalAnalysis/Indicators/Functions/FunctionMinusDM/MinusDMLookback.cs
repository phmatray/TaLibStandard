using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMinusDM;

/// <summary>
/// Minus Directional Movement Lookback
/// </summary>
public record MinusDMLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MinusDMLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public MinusDMLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod + (int)TACore.Globals.UnstablePeriods[FuncUnstId.MinusDM] - 1;
        }
    }
}
