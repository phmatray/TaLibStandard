﻿using TechnicalAnalysis.Common;

namespace TechnicalAnalysis.Functions.FunctionMidPrice;

/// <summary>
/// Midpoint Price over period Lookback
/// </summary>
public record MidPriceLookback : Lookback
{
    /// <summary>
    /// Constructor for <see cref="MidPriceLookback"/> record.
    /// </summary>
    /// <param name="optInTimePeriod">Number of period (From 2 to 100000)</param>
    public MidPriceLookback(int optInTimePeriod = 14)
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
