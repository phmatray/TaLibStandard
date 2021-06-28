using System;
using System.Linq;
using GLPM.TechnicalAnalysis.Business;

namespace GLPM.TechnicalAnalysis.Ui.Cli
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("GLPM.TechnicalAnalysis");

            var dataA = DataHistoryRepository
                .GetDataHistoryFromFile("btc", "eur", "day")
                .ComputeMacd()
                .ComputeMovingAverage()
                .ComputeBbands()
                .ComputeRsi();

            var dataAIndicator = dataA.Indicators[Indicator.Macd];

            var data = DataHistoryRepository.GetDataHistoryFromFile("eth", "eur", "day");
            var macdResult = data.ComputeMacd().Indicators.Last();
            var movingAverageResult = data.ComputeMovingAverage().Indicators.Last();



            // var historicalDataB = DataHistoryRepository.GetDataHistoryFromService("btc", "eur", "day");
            // var rsiResult = historicalDataB.ComputeIndicator(Indicator.Rsi);
            // var bbandsResult = historicalDataB.ComputeIndicator(Indicator.Bbands);
            // var kamaResult = historicalDataB.ComputeIndicator(Indicator.Kama);
            // var stochRsiResult = historicalDataB.ComputeIndicator(Indicator.StochRsi);

            for (int i = 0; i < data.Count; i++)
            {
                Console.WriteLine(
                    $"Candle {i:000}   O: {data.Open[i]:N8}  "
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
        }
    }
}
