using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionLinearReg;

/// <summary>
/// Linear Regression Lookback
/// </summary>
public record LinearRegLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="LinearRegLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public LinearRegLookback(int optInTimePeriod = 14)
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
