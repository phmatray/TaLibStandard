using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionVariance;

/// <summary>
/// Variance Lookback
/// </summary>
public record VarianceLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="VarianceLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 1 to 100000)</param>
    public VarianceLookback(int optInTimePeriod = 5)
    {
        if (optInTimePeriod is < 1 or > 100000)
        {
            Result = -1;
        }
        else
        {
            Result = optInTimePeriod - 1;
        }
    }
}
