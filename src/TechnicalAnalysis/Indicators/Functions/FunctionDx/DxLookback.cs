using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionDx;

/// <summary>
/// Directional Movement Index Lookback
/// </summary>
public record DxLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="DxLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public DxLookback(int optInTimePeriod = 14)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod + (int)TACore.Globals.UnstablePeriods[FuncUnstId.Dx];
        }
    }
}
