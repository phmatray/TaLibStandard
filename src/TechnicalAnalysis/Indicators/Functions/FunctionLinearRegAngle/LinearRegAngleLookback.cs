using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionLinearRegAngle;

/// <summary>
/// Linear Regression Angle Lookback
/// </summary>
public record LinearRegAngleLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="LinearRegAngleLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public LinearRegAngleLookback(int optInTimePeriod = 14)
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
