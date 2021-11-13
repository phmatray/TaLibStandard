using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionLinearRegSlope;

/// <summary>
/// Linear Regression Slope Lookback
/// </summary>
public record LinearRegSlopeLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="LinearRegSlopeLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public LinearRegSlopeLookback(int optInTimePeriod = 14)
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
