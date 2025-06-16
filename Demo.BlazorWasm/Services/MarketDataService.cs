using Demo.BlazorWasm.Models;

namespace Demo.BlazorWasm.Services;

public class MarketDataService : IMarketDataService
{
    private readonly HttpClient _httpClient;
    private readonly Random _random = new();

    public MarketDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<StockData>> GetHistoricalDataAsync(string symbol, int days = 100)
    {
        // In a real application, this would call Yahoo Finance API
        // For the demo, we'll generate sample data
        await Task.Delay(500); // Simulate API call
        return GenerateSampleData(days);
    }

    public async Task<List<string>> SearchSymbolsAsync(string query)
    {
        // Simulate symbol search
        await Task.Delay(300);

        List<string> symbols =
        [
            "AAPL", "MSFT", "GOOGL", "AMZN", "META", "TSLA", "NVDA", "JPM", "JNJ", "V",
            "PG", "UNH", "MA", "HD", "DIS", "PYPL", "BAC", "VZ", "ADBE", "NFLX"
        ];

        return
        [
            .. symbols
                .Where(s => s.Contains(query, StringComparison.OrdinalIgnoreCase))
                .Take(10)
        ];
    }

    public List<StockData> GenerateSampleData(int days = 100)
    {
        List<StockData> data = [];
        decimal basePrice = 100m + _random.Next(50, 200);
        DateTime currentDate = DateTime.Now.Date;

        for (int i = days - 1; i >= 0; i--)
        {
            DateTime date = currentDate.AddDays(-i);
            decimal dailyChange = (decimal)((_random.NextDouble() * 10) - 5); // -5% to +5%
            basePrice *= 1 + (dailyChange / 100);

            decimal open = basePrice + (decimal)((_random.NextDouble() * 2) - 1);
            decimal close = basePrice + (decimal)((_random.NextDouble() * 2) - 1);
            decimal high = Math.Max(open, close) + (decimal)(_random.NextDouble() * 2);
            decimal low = Math.Min(open, close) - (decimal)(_random.NextDouble() * 2);
            int volume = _random.Next(1000000, 10000000);

            data.Add(new StockData
            {
                Date = date,
                Open = Math.Round(open, 2),
                High = Math.Round(high, 2),
                Low = Math.Round(low, 2),
                Close = Math.Round(close, 2),
                Volume = volume
            });
        }

        return data;
    }
}