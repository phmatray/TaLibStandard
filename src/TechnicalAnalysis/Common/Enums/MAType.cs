namespace TechnicalAnalysis.Common;

/// <summary>
/// Moving Average Type
/// </summary>
public enum MAType
{
    /// <summary>
    /// Simple Moving Average
    /// </summary>
    Sma,

    /// <summary>
    /// Exponential Moving Average
    /// </summary>
    Ema,
        
    /// <summary>
    /// Weight Moving Average
    /// </summary>
    Wma,
        
    /// <summary>
    /// Double Exponential Moving Average
    /// </summary>
    Dema,
        
    /// <summary>
    /// Triple Exponential Moving Average
    /// </summary>
    Tema,
        
    /// <summary>
    /// Triangular Moving Average
    /// </summary>
    Trima,
        
    /// <summary>
    /// Kaufman's Adaptive Moving Average
    /// </summary>
    Kama,
        
    /// <summary>
    /// MESA Adaptive Moving Average
    /// </summary>
    Mama,
        
    /// <summary>
    /// Tilson T3 Moving Average
    /// </summary>
    T3
}
