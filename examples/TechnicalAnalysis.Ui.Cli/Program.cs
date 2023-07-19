using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalAnalysis.Business;
using TechnicalAnalysis.Common;

Console.WriteLine("TechnicalAnalysis");

#pragma warning disable S125

DataHistory dataA = DataHistoryRepository
    .GetDataHistoryFromFile("btc", "eur", "day")
    .ComputeMacd()
    .ComputeMovingAverage()
    .ComputeBollingerBands()
    .ComputeRsi();

IndicatorBase dataAIndicator = dataA.Indicators[Indicator.Macd];

DataHistory data = DataHistoryRepository.GetDataHistoryFromFile("eth", "eur", "day");
KeyValuePair<Indicator, IndicatorBase> macdResult = data.ComputeMacd().Indicators.Last();
KeyValuePair<Indicator, IndicatorBase> movingAverageResult = data.ComputeMovingAverage().Indicators.Last();


// var historicalDataB = DataHistoryRepository.GetDataHistoryFromService("btc", "eur", "day");
// var rsiResult = historicalDataB.ComputeIndicator(Indicator.Rsi);
// var bollingerBandsResult = historicalDataB.ComputeIndicator(Indicator.BollingerBands);
// var kamaResult = historicalDataB.ComputeIndicator(Indicator.Kama);
// var stochRsiResult = historicalDataB.ComputeIndicator(Indicator.StochRsi);

for (int i = 0; i < data.Count; i++)
{
    Console.WriteLine(
        $"Candle {i:000}   "
        + $"O: {data.Open[i]:N8}  "
        + $"H: {data.High[i]:N8}  "
        + $"L: {data.Low[i]:N8}  "
        + $"C: {data.Close[i]:N8}  ");

    //if (i >= macdResult.BegIdx)
    //{
    //    Console.WriteLine(
    //        $"  Macd: {macdResult.Macd[i - macdResult.BegIdx]:N8}  "
    //        + $"Hist: {macdResult.MacdHist[i - macdResult.BegIdx]:N8}  "
    //        + $"Signal: {macdResult.MacdSignal[i - macdResult.BegIdx]:N8}");
    //}

    //if (i >= movingAverageResult.BegIdx)
    //{
    //    Console.WriteLine($"  MovAvg: {movingAverageResult.Real[i - movingAverageResult.BegIdx]:N8}");
    //}

    // Console.WriteLine();
}

Console.ReadLine();

#pragma warning restore S125
