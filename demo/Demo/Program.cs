using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Demo.Extensions;
using Demo.WIP;
using TechnicalAnalysis.Candles;
using TechnicalAnalysis.Common;

Console.WriteLine("Demo Technical Analysis Library");
Console.WriteLine("------------------------------");
Console.WriteLine();

try
{
    // Create an observable sequence that generates a new candle every second.
    var candles = Observable.Interval(TimeSpan.FromSeconds(1))
        .Select(_ => TACandleFactory.Create(RandomValue(), RandomValue(), RandomValue(), RandomValue()))
        .ObserveOn(TaskPoolScheduler.Default); // Ensure that the subscription runs on a separate thread.

    // Subscribe to the sequence and handle each new candle.
    using IDisposable subscription = candles
        .Subscribe(
            candle =>
            {
                Console.WriteLine($"New candle created: Open={candle.Open}, High={candle.High}, Low={candle.Low}, Close={candle.Close}");
            },
            ex =>
            {
                // Log any errors that occur during the subscription.
                Console.WriteLine($"An error occurred: {ex.Message}");
            });

    // Keep the program running until the user presses a key.
    Console.WriteLine("Press any key to exit...");
    Console.ReadKey();
}
catch (Exception ex)
{
    // Log any errors that occur during the setup of the observable sequence.
    Console.WriteLine($"An error occurred: {ex.Message}");
}
return;


// Generate a random floating point value.
static float RandomValue()
{
    var random = new Random();
    return (float)random.NextDouble() * 100;
}



////////////


// float[] open  = Enumerable.Repeat(0f, 12).Concat([100f, 135f, 130f]).ToArray();
// float[] high  = Enumerable.Repeat(0f, 12).Concat([140f, 140f, 140f]).ToArray();
// float[] low   = Enumerable.Repeat(0f, 12).Concat([110f, 110f, 110f]).ToArray();
// float[] close = Enumerable.Repeat(0f, 12).Concat([120f, 125f, 110f]).ToArray();
//
// IEnumerable<TACandle<float>> candles = TACandleFactory.Create(open, high, low, close);
//
//
// foreach (var taCandle in candles)
// {
//     Console.WriteLine($"Open: {taCandle.Open}, High: {taCandle.High}, Low: {taCandle.Low}, Close: {taCandle.Close}");
// }
//
// CandleIndicatorResult result1 = TACandle.Cdl2Crows(0, 15, open, high, low, close);
// CandleIndicatorResult result2 = TACandle.CdlDoji(0, 15, open, high, low, close);
// CandleIndicatorResult result3 = TACandle.CdlDojiStar(0, 15, open, high, low, close);
//
// Console.WriteLine($"Candle2Crows  : {result1.Integers.ToReadableString()}");
// Console.WriteLine($"CandleDoji    : {result2.Integers.ToReadableString()}");
// Console.WriteLine($"CandleDojiStar: {result3.Integers.ToReadableString()}");

