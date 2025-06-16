using Demo.BlazorWasm.Models;
using TechnicalAnalysis.Common;

namespace Demo.BlazorWasm.Services;

public interface ITechnicalAnalysisService
{
    // Moving Averages
    TaIndicatorResult CalculateSMA(List<StockData> data, int period);
    TaIndicatorResult CalculateEMA(List<StockData> data, int period);
    
    // Momentum Indicators
    TaIndicatorResult CalculateRSI(List<StockData> data, int period = 14);
    MacdResult CalculateMACD(List<StockData> data, int fastPeriod = 12, int slowPeriod = 26, int signalPeriod = 9);
    
    // Volatility Indicators
    BollingerBandsResult CalculateBollingerBands(List<StockData> data, int period = 20, double devUp = 2, double devDown = 2);
    AtrResult CalculateATR(List<StockData> data, int period = 14);
    
    // Volume Indicators
    ObvResult CalculateOBV(List<StockData> data);
    
    // Pattern Recognition
    List<CandlePatternResult> DetectCandlePatterns(List<StockData> data);
    List<CandlePatternResult> DetectCandlePatterns(List<StockData> data, HashSet<string> enabledPatterns);
}

public class TaIndicatorResult
{
    public RetCode RetCode { get; set; }
    public int BegIdx { get; set; }
    public int NBElement { get; set; }
    public double[] Values { get; set; } = Array.Empty<double>();
}

public class MacdResult : TaIndicatorResult
{
    public double[] Signal { get; set; } = Array.Empty<double>();
    public double[] Histogram { get; set; } = Array.Empty<double>();
}

public class BollingerBandsResult : TaIndicatorResult
{
    public double[] UpperBand { get; set; } = Array.Empty<double>();
    public double[] LowerBand { get; set; } = Array.Empty<double>();
}

public class AtrResult : TaIndicatorResult
{
}

public class ObvResult : TaIndicatorResult
{
}

public class CandlePatternResult
{
    public string PatternName { get; set; } = string.Empty;
    public int Index { get; set; }
    public int Value { get; set; }
    public string Signal => Value > 0 ? "Bullish" : Value < 0 ? "Bearish" : "Neutral";
}