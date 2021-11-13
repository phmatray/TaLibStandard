using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionTrima;

/// <summary>
/// Triangular Moving Average Lookback
/// </summary>
public record TrimaLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="TrimaLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public TrimaLookback(int optInTimePeriod = 30)
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
