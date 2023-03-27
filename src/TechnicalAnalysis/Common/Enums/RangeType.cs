namespace TechnicalAnalysis.Common;

/// <summary>
/// Represents the different types of price ranges.
/// </summary>
public enum RangeType
{
    /// <summary>
    /// Represents the range between the open and close prices of a candlestick.
    /// </summary>
    RealBody,

    /// <summary>
    /// Represents the range between the highest and lowest prices of a candlestick.
    /// </summary>
    HighLow,

    /// <summary>
    /// Represents the range of the shadows (upper and lower wicks) of a candlestick.
    /// </summary>
    Shadows
}
