using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionLinearRegIntercept;

/// <summary>
/// Linear Regression Intercept Lookback
/// </summary>
public record LinearRegInterceptLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="LinearRegInterceptLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public LinearRegInterceptLookback(int optInTimePeriod = 14)
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
