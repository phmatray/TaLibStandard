using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions.FunctionVariance;

namespace TechnicalAnalysis.Functions.FunctionStdDev;

/// <summary>
/// Standard Deviation Lookback
/// </summary>
public record StdDevLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="StdDevLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    /// <param name="optInNbDev">Nb of deviations</param>
    public StdDevLookback(int optInTimePeriod = 5, double optInNbDev = 1.0)
    {
        if (optInTimePeriod is < 2 or > 100000)
        {
            Result = -1;
        }
        else
        {
            // Lookback is driven by the variance.
            Result = new VarianceLookback(optInTimePeriod).Result;
        }
    }
}
