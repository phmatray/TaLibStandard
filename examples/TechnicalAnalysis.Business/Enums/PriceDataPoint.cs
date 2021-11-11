namespace TechnicalAnalysis.Business;

/// <summary>
/// Price bars are composed of an open, a high, a low and a close. 
/// With this enumeration, the trader can choose which of these data points the indicator will use in its calculation
/// </summary>
/// <remarks>https://www.thebalance.com/average-of-the-open-high-low-and-close-1031216</remarks>
public enum PriceDataPoint
{
    Open,
    High,
    Low,
    Close,
    Average
}