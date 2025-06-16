using Demo.BlazorWasm.Models;
using TechnicalAnalysis.Common;
using TechnicalAnalysis.Functions;
using TechnicalAnalysis.Candles;

namespace Demo.BlazorWasm.Services;

public class TechnicalAnalysisService : ITechnicalAnalysisService
{
    public TaIndicatorResult CalculateSMA(List<StockData> data, int period)
    {
        double[] closes = [.. data.Select(d => (double)d.Close)];
        double[] outReal = new double[closes.Length];
        int outBegIdx = 0;
        int outNbElement = 0;

        RetCode result = TAFunc.Sma(
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
            Values = [.. outReal.Take(outNbElement)]
        };
    }

    public TaIndicatorResult CalculateEMA(List<StockData> data, int period)
    {
        double[] closes = [.. data.Select(d => (double)d.Close)];
        double[] outReal = new double[closes.Length];
        int outBegIdx = 0;
        int outNbElement = 0;

        RetCode result = TAFunc.Ema(
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
            Values = [.. outReal.Take(outNbElement)]
        };
    }

    public TaIndicatorResult CalculateRSI(List<StockData> data, int period = 14)
    {
        double[] closes = [.. data.Select(d => (double)d.Close)];
        double[] outReal = new double[closes.Length];
        int outBegIdx = 0;
        int outNbElement = 0;

        RetCode result = TAFunc.Rsi(
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
            Values = [.. outReal.Take(outNbElement)]
        };
    }

    public MacdResult CalculateMACD(List<StockData> data, int fastPeriod = 12, int slowPeriod = 26, int signalPeriod = 9)
    {
        double[] closes = [.. data.Select(d => (double)d.Close)];
        double[] outMACD = new double[closes.Length];
        double[] outMACDSignal = new double[closes.Length];
        double[] outMACDHist = new double[closes.Length];
        int outBegIdx = 0;
        int outNbElement = 0;

        RetCode result = TAFunc.Macd(
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
            Values = [.. outMACD.Take(outNbElement)],
            Signal = [.. outMACDSignal.Take(outNbElement)],
            Histogram = [.. outMACDHist.Take(outNbElement)]
        };
    }

    public BollingerBandsResult CalculateBollingerBands(List<StockData> data, int period = 20, double devUp = 2, double devDown = 2)
    {
        double[] closes = [.. data.Select(d => (double)d.Close)];
        double[] outRealUpperBand = new double[closes.Length];
        double[] outRealMiddleBand = new double[closes.Length];
        double[] outRealLowerBand = new double[closes.Length];
        int outBegIdx = 0;
        int outNbElement = 0;

        RetCode result = TAFunc.BollingerBands(
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
            Values = [.. outRealMiddleBand.Take(outNbElement)],
            UpperBand = [.. outRealUpperBand.Take(outNbElement)],
            LowerBand = [.. outRealLowerBand.Take(outNbElement)]
        };
    }

    public AtrResult CalculateATR(List<StockData> data, int period = 14)
    {
        double[] high = [.. data.Select(d => (double)d.High)];
        double[] low = [.. data.Select(d => (double)d.Low)];
        double[] close = [.. data.Select(d => (double)d.Close)];
        double[] outReal = new double[close.Length];
        int outBegIdx = 0;
        int outNbElement = 0;

        RetCode result = TAFunc.Atr(
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
            Values = [.. outReal.Take(outNbElement)]
        };
    }

    public ObvResult CalculateOBV(List<StockData> data)
    {
        double[] closes = [.. data.Select(d => (double)d.Close)];
        double[] volumes = [.. data.Select(d => (double)d.Volume)];
        double[] outReal = new double[closes.Length];
        int outBegIdx = 0;
        int outNbElement = 0;

        RetCode result = TAFunc.Obv(
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
            Values = [.. outReal.Take(outNbElement)]
        };
    }

    public List<CandlePatternResult> DetectCandlePatterns(List<StockData> data)
    {
        // Detect all patterns by default
        return DetectCandlePatterns(data, null);
    }

    public List<CandlePatternResult> DetectCandlePatterns(List<StockData> data, HashSet<string>? enabledPatterns)
    {
        List<CandlePatternResult> results = [];

        if (data == null || data.Count < 10)
        {
            return results;
        }

        double[] open = [.. data.Select(d => (double)d.Open)];
        double[] high = [.. data.Select(d => (double)d.High)];
        double[] low = [.. data.Select(d => (double)d.Low)];
        double[] close = [.. data.Select(d => (double)d.Close)];

        // Define all pattern detectors
        Dictionary<string, Func<CandleIndicatorResult>> patternDetectors = new Dictionary<string, Func<CandleIndicatorResult>>
        {
            // Two Crows
            ["2Crows"] = () => TACandle.Cdl2Crows(0, data.Count - 1, open, high, low, close),

            // Three Black Crows
            ["3BlackCrows"] = () => TACandle.Cdl3BlackCrows(0, data.Count - 1, open, high, low, close),

            // Three Inside Up/Down
            ["3Inside"] = () => TACandle.Cdl3Inside(0, data.Count - 1, open, high, low, close),

            // Three-Line Strike
            ["3LineStrike"] = () => TACandle.Cdl3LineStrike(0, data.Count - 1, open, high, low, close),

            // Three Outside Up/Down
            ["3Outside"] = () => TACandle.Cdl3Outside(0, data.Count - 1, open, high, low, close),

            // Three Stars In The South
            ["3StarsInSouth"] = () => TACandle.Cdl3StarsInSouth(0, data.Count - 1, open, high, low, close),

            // Three Advancing White Soldiers
            ["3WhiteSoldiers"] = () => TACandle.Cdl3WhiteSoldiers(0, data.Count - 1, open, high, low, close),

            // Abandoned Baby
            ["AbandonedBaby"] = () => TACandle.CdlAbandonedBaby(0, data.Count - 1, open, high, low, close),

            // Advance Block
            ["AdvanceBlock"] = () => TACandle.CdlAdvanceBlock(0, data.Count - 1, open, high, low, close),

            // Belt-hold
            ["BeltHold"] = () => TACandle.CdlBeltHold(0, data.Count - 1, open, high, low, close),

            // Breakaway
            ["Breakaway"] = () => TACandle.CdlBreakaway(0, data.Count - 1, open, high, low, close),

            // Closing Marubozu
            ["ClosingMarubozu"] = () => TACandle.CdlClosingMarubozu(0, data.Count - 1, open, high, low, close),

            // Concealing Baby Swallow
            ["ConcealBabySwallow"] = () => TACandle.CdlConcealBabySwallow(0, data.Count - 1, open, high, low, close),

            // Counterattack
            ["CounterAttack"] = () => TACandle.CdlCounterAttack(0, data.Count - 1, open, high, low, close),

            // Dark Cloud Cover
            ["DarkCloudCover"] = () => TACandle.CdlDarkCloudCover(0, data.Count - 1, open, high, low, close),

            // Doji
            ["Doji"] = () => TACandle.CdlDoji(0, data.Count - 1, open, high, low, close),

            // Doji Star
            ["DojiStar"] = () => TACandle.CdlDojiStar(0, data.Count - 1, open, high, low, close),

            // Dragonfly Doji
            ["DragonflyDoji"] = () => TACandle.CdlDragonflyDoji(0, data.Count - 1, open, high, low, close),

            // Engulfing Pattern
            ["Engulfing"] = () => TACandle.CdlEngulfing(0, data.Count - 1, open, high, low, close),

            // Evening Doji Star
            ["EveningDojiStar"] = () => TACandle.CdlEveningDojiStar(0, data.Count - 1, open, high, low, close),

            // Evening Star
            ["EveningStar"] = () => TACandle.CdlEveningStar(0, data.Count - 1, open, high, low, close),

            // Up/Down-gap side-by-side white lines
            ["GapSideSideWhite"] = () => TACandle.CdlGapSideSideWhite(0, data.Count - 1, open, high, low, close),

            // Gravestone Doji
            ["GravestoneDoji"] = () => TACandle.CdlGravestoneDoji(0, data.Count - 1, open, high, low, close),

            // Hammer
            ["Hammer"] = () => TACandle.CdlHammer(0, data.Count - 1, open, high, low, close),

            // Hanging Man
            ["HangingMan"] = () => TACandle.CdlHangingMan(0, data.Count - 1, open, high, low, close),

            // Harami Pattern
            ["Harami"] = () => TACandle.CdlHarami(0, data.Count - 1, open, high, low, close),

            // Harami Cross Pattern
            ["HaramiCross"] = () => TACandle.CdlHaramiCross(0, data.Count - 1, open, high, low, close),

            // High-Wave Candle
            ["HighWave"] = () => TACandle.CdlHighWave(0, data.Count - 1, open, high, low, close),

            // Hikkake Pattern
            ["Hikkake"] = () => TACandle.CdlHikkake(0, data.Count - 1, open, high, low, close),

            // Modified Hikkake Pattern
            ["HikkakeMod"] = () => TACandle.CdlHikkakeMod(0, data.Count - 1, open, high, low, close),

            // Homing Pigeon
            ["HomingPigeon"] = () => TACandle.CdlHomingPigeon(0, data.Count - 1, open, high, low, close),

            // Identical Three Crows
            ["Identical3Crows"] = () => TACandle.CdlIdentical3Crows(0, data.Count - 1, open, high, low, close),

            // In-Neck Pattern
            ["InNeck"] = () => TACandle.CdlInNeck(0, data.Count - 1, open, high, low, close),

            // Inverted Hammer
            ["InvertedHammer"] = () => TACandle.CdlInvertedHammer(0, data.Count - 1, open, high, low, close),

            // Kicking
            ["Kicking"] = () => TACandle.CdlKicking(0, data.Count - 1, open, high, low, close),

            // Kicking - bull/bear determined by the longer marubozu
            ["KickingByLength"] = () => TACandle.CdlKickingByLength(0, data.Count - 1, open, high, low, close),

            // Ladder Bottom
            ["LadderBottom"] = () => TACandle.CdlLadderBottom(0, data.Count - 1, open, high, low, close),

            // Long Legged Doji
            ["LongLeggedDoji"] = () => TACandle.CdlLongLeggedDoji(0, data.Count - 1, open, high, low, close),

            // Long Line Candle
            ["LongLine"] = () => TACandle.CdlLongLine(0, data.Count - 1, open, high, low, close),

            // Marubozu
            ["Marubozu"] = () => TACandle.CdlMarubozu(0, data.Count - 1, open, high, low, close),

            // Matching Low
            ["MatchingLow"] = () => TACandle.CdlMatchingLow(0, data.Count - 1, open, high, low, close),

            // Mat Hold
            ["MatHold"] = () => TACandle.CdlMatHold(0, data.Count - 1, open, high, low, close),

            // Morning Doji Star
            ["MorningDojiStar"] = () => TACandle.CdlMorningDojiStar(0, data.Count - 1, open, high, low, close),

            // Morning Star
            ["MorningStar"] = () => TACandle.CdlMorningStar(0, data.Count - 1, open, high, low, close),

            // On-Neck Pattern
            ["OnNeck"] = () => TACandle.CdlOnNeck(0, data.Count - 1, open, high, low, close),

            // Piercing Pattern
            ["Piercing"] = () => TACandle.CdlPiercing(0, data.Count - 1, open, high, low, close),

            // Rickshaw Man
            ["RickshawMan"] = () => TACandle.CdlRickshawMan(0, data.Count - 1, open, high, low, close),

            // Rising/Falling Three Methods
            ["RiseFall3Methods"] = () => TACandle.CdlRiseFall3Methods(0, data.Count - 1, open, high, low, close),

            // Separating Lines
            ["SeparatingLines"] = () => TACandle.CdlSeparatingLines(0, data.Count - 1, open, high, low, close),

            // Shooting Star
            ["ShootingStar"] = () => TACandle.CdlShootingStar(0, data.Count - 1, open, high, low, close),

            // Short Line Candle
            ["ShortLine"] = () => TACandle.CdlShortLine(0, data.Count - 1, open, high, low, close),

            // Spinning Top
            ["SpinningTop"] = () => TACandle.CdlSpinningTop(0, data.Count - 1, open, high, low, close),

            // Stalled Pattern
            ["StalledPattern"] = () => TACandle.CdlStalledPattern(0, data.Count - 1, open, high, low, close),

            // Stick Sandwich
            ["StickSandwich"] = () => TACandle.CdlStickSandwich(0, data.Count - 1, open, high, low, close),

            // Takuri (Dragonfly Doji with very long lower shadow)
            ["Takuri"] = () => TACandle.CdlTakuri(0, data.Count - 1, open, high, low, close),

            // Tasuki Gap
            ["TasukiGap"] = () => TACandle.CdlTasukiGap(0, data.Count - 1, open, high, low, close),

            // Thrusting Pattern
            ["Thrusting"] = () => TACandle.CdlThrusting(0, data.Count - 1, open, high, low, close),

            // Tristar Pattern
            ["Tristar"] = () => TACandle.CdlTristar(0, data.Count - 1, open, high, low, close),

            // Unique 3 River
            ["Unique3River"] = () => TACandle.CdlUnique3River(0, data.Count - 1, open, high, low, close),

            // Upside Gap Two Crows
            ["UpsideGap2Crows"] = () => TACandle.CdlUpsideGap2Crows(0, data.Count - 1, open, high, low, close),

            // Upside/Downside Gap Three Methods
            ["XSideGap3Methods"] = () => TACandle.CdlXSideGap3Methods(0, data.Count - 1, open, high, low, close)
        };

        // Detect patterns
        foreach (KeyValuePair<string, Func<CandleIndicatorResult>> kvp in patternDetectors)
        {
            string patternName = kvp.Key;

            // Skip if not in enabled patterns (when specified)
            if (enabledPatterns != null && !enabledPatterns.Contains(patternName))
            {
                continue;
            }

            Func<CandleIndicatorResult> detector = kvp.Value;

            try
            {
                CandleIndicatorResult result = detector();

                if (result.RetCode == RetCode.Success)
                {
                    for (int i = 0; i < result.NBElement; i++)
                    {
                        if (result.Integers[i] != 0)
                        {
                            results.Add(new CandlePatternResult
                            {
                                PatternName = patternName,
                                Index = result.BegIdx + i,
                                Value = result.Integers[i]
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error but continue with other patterns
                Console.WriteLine($"Error detecting pattern {patternName}: {ex.Message}");
            }
        }

        return [.. results.OrderBy(r => r.Index)];
    }
}