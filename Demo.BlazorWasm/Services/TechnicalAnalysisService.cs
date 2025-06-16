using Demo.BlazorWasm.Models;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;
using TechnicalAnalysis.Candles;

namespace Demo.BlazorWasm.Services;

public class TechnicalAnalysisService : ITechnicalAnalysisService
{
    public TaIndicatorResult CalculateSMA(List<StockData> data, int period)
    {
        var closes = data.Select(d => (double)d.Close).ToArray();
        var outReal = new double[closes.Length];
        var outBegIdx = 0;
        var outNbElement = 0;
        
        var result = TAFunc.Sma(
            0, closes.Length - 1,
            in closes,
            in period,
            ref outBegIdx,
            ref outNbElement,
            ref outReal
        );

        return new TaIndicatorResult
        {
            RetCode = result,
            BegIdx = outBegIdx,
            NBElement = outNbElement,
            Values = outReal.Take(outNbElement).ToArray()
        };
    }

    public TaIndicatorResult CalculateEMA(List<StockData> data, int period)
    {
        var closes = data.Select(d => (double)d.Close).ToArray();
        var outReal = new double[closes.Length];
        var outBegIdx = 0;
        var outNbElement = 0;
        
        var result = TAFunc.Ema(
            0, closes.Length - 1,
            in closes,
            in period,
            ref outBegIdx,
            ref outNbElement,
            ref outReal
        );

        return new TaIndicatorResult
        {
            RetCode = result,
            BegIdx = outBegIdx,
            NBElement = outNbElement,
            Values = outReal.Take(outNbElement).ToArray()
        };
    }

    public TaIndicatorResult CalculateRSI(List<StockData> data, int period = 14)
    {
        var closes = data.Select(d => (double)d.Close).ToArray();
        var outReal = new double[closes.Length];
        var outBegIdx = 0;
        var outNbElement = 0;
        
        var result = TAFunc.Rsi(
            0, closes.Length - 1,
            in closes,
            in period,
            ref outBegIdx,
            ref outNbElement,
            ref outReal
        );

        return new TaIndicatorResult
        {
            RetCode = result,
            BegIdx = outBegIdx,
            NBElement = outNbElement,
            Values = outReal.Take(outNbElement).ToArray()
        };
    }

    public MacdResult CalculateMACD(List<StockData> data, int fastPeriod = 12, int slowPeriod = 26, int signalPeriod = 9)
    {
        var closes = data.Select(d => (double)d.Close).ToArray();
        var outMACD = new double[closes.Length];
        var outMACDSignal = new double[closes.Length];
        var outMACDHist = new double[closes.Length];
        var outBegIdx = 0;
        var outNbElement = 0;
        
        var result = TAFunc.Macd(
            0, closes.Length - 1,
            in closes,
            in fastPeriod,
            in slowPeriod,
            in signalPeriod,
            ref outBegIdx,
            ref outNbElement,
            ref outMACD,
            ref outMACDSignal,
            ref outMACDHist
        );

        return new MacdResult
        {
            RetCode = result,
            BegIdx = outBegIdx,
            NBElement = outNbElement,
            Values = outMACD.Take(outNbElement).ToArray(),
            Signal = outMACDSignal.Take(outNbElement).ToArray(),
            Histogram = outMACDHist.Take(outNbElement).ToArray()
        };
    }

    public BollingerBandsResult CalculateBollingerBands(List<StockData> data, int period = 20, double devUp = 2, double devDown = 2)
    {
        var closes = data.Select(d => (double)d.Close).ToArray();
        var outRealUpperBand = new double[closes.Length];
        var outRealMiddleBand = new double[closes.Length];
        var outRealLowerBand = new double[closes.Length];
        var outBegIdx = 0;
        var outNbElement = 0;
        
        var result = TAFunc.BollingerBands(
            0, closes.Length - 1,
            in closes,
            in period,
            in devUp,
            in devDown,
            MAType.Sma,
            ref outBegIdx,
            ref outNbElement,
            ref outRealUpperBand,
            ref outRealMiddleBand,
            ref outRealLowerBand
        );

        return new BollingerBandsResult
        {
            RetCode = result,
            BegIdx = outBegIdx,
            NBElement = outNbElement,
            Values = outRealMiddleBand.Take(outNbElement).ToArray(),
            UpperBand = outRealUpperBand.Take(outNbElement).ToArray(),
            LowerBand = outRealLowerBand.Take(outNbElement).ToArray()
        };
    }

    public AtrResult CalculateATR(List<StockData> data, int period = 14)
    {
        var high = data.Select(d => (double)d.High).ToArray();
        var low = data.Select(d => (double)d.Low).ToArray();
        var close = data.Select(d => (double)d.Close).ToArray();
        var outReal = new double[close.Length];
        var outBegIdx = 0;
        var outNbElement = 0;
        
        var result = TAFunc.Atr(
            0, close.Length - 1,
            in high,
            in low,
            in close,
            in period,
            ref outBegIdx,
            ref outNbElement,
            ref outReal
        );

        return new AtrResult
        {
            RetCode = result,
            BegIdx = outBegIdx,
            NBElement = outNbElement,
            Values = outReal.Take(outNbElement).ToArray()
        };
    }

    public ObvResult CalculateOBV(List<StockData> data)
    {
        var closes = data.Select(d => (double)d.Close).ToArray();
        var volumes = data.Select(d => (double)d.Volume).ToArray();
        var outReal = new double[closes.Length];
        var outBegIdx = 0;
        var outNbElement = 0;
        
        var result = TAFunc.Obv(
            0, closes.Length - 1,
            in closes,
            in volumes,
            ref outBegIdx,
            ref outNbElement,
            ref outReal
        );

        return new ObvResult
        {
            RetCode = result,
            BegIdx = outBegIdx,
            NBElement = outNbElement,
            Values = outReal.Take(outNbElement).ToArray()
        };
    }

    public List<CandlePatternResult> DetectCandlePatterns(List<StockData> data)
    {
        var results = new List<CandlePatternResult>();
        var open = data.Select(d => (double)d.Open).ToArray();
        var high = data.Select(d => (double)d.High).ToArray();
        var low = data.Select(d => (double)d.Low).ToArray();
        var close = data.Select(d => (double)d.Close).ToArray();

        // Check for Doji patterns
        var dojiResult = TACandle.CdlDoji(0, data.Count - 1, open, high, low, close);
        
        if (dojiResult.RetCode == RetCode.Success)
        {
            for (int i = 0; i < dojiResult.NBElement; i++)
            {
                if (dojiResult.Integers[i] != 0)
                {
                    results.Add(new CandlePatternResult
                    {
                        PatternName = "Doji",
                        Index = dojiResult.BegIdx + i,
                        Value = dojiResult.Integers[i]
                    });
                }
            }
        }

        // Check for Hammer patterns
        var hammerResult = TACandle.CdlHammer(0, data.Count - 1, open, high, low, close);
        
        if (hammerResult.RetCode == RetCode.Success)
        {
            for (int i = 0; i < hammerResult.NBElement; i++)
            {
                if (hammerResult.Integers[i] != 0)
                {
                    results.Add(new CandlePatternResult
                    {
                        PatternName = "Hammer",
                        Index = hammerResult.BegIdx + i,
                        Value = hammerResult.Integers[i]
                    });
                }
            }
        }

        // Check for Engulfing patterns
        var engulfingResult = TACandle.CdlEngulfing(0, data.Count - 1, open, high, low, close);
        
        if (engulfingResult.RetCode == RetCode.Success)
        {
            for (int i = 0; i < engulfingResult.NBElement; i++)
            {
                if (engulfingResult.Integers[i] != 0)
                {
                    results.Add(new CandlePatternResult
                    {
                        PatternName = "Engulfing",
                        Index = engulfingResult.BegIdx + i,
                        Value = engulfingResult.Integers[i]
                    });
                }
            }
        }

        return results.OrderBy(r => r.Index).ToList();
    }
}