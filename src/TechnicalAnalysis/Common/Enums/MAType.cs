namespace TechnicalAnalysis.Common;

/// <summary>
/// Moving Average Type
/// </summary>
public enum MAType
{
    /// <summary>
    /// Simple Moving Average
    /// </summary>
    Sma = 0,

    /// <summary>
    /// Exponential Moving Average
    /// </summary>
    Ema = 1,

    /// <summary>
    /// Weight Moving Average
    /// </summary>
    Wma = 2,

    /// <summary>
    /// Double Exponential Moving Average
    /// </summary>
    Dema = 3,

    /// <summary>
    /// Triple Exponential Moving Average
    /// </summary>
    Tema = 4,

    /// <summary>
    /// Triangular Moving Average
    /// </summary>
    Trima = 5,

    /// <summary>
    /// Kaufman's Adaptive Moving Average
    /// </summary>
    Kama = 6,

    /// <summary>
    /// MESA Adaptive Moving Average
    /// </summary>
    Mama = 7,

    /// <summary>
    /// Tilson T3 Moving Average
    /// </summary>
    T3 = 8
}
