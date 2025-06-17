using System.Text.Json;
using Demo.BlazorWasm.Models;

namespace Demo.BlazorWasm.Services;

public class MarketDataService(HttpClient httpClient) : IMarketDataService
{
    public async Task<List<StockData>> GetHistoricalDataAsync(string symbol, int days = 100)
    {
        try
        {
            // Calculate date range
            DateTime endDate = DateTime.Now;
            DateTime startDate = endDate.AddDays(-days);

            // Convert to Unix timestamps
            long period1 = ((DateTimeOffset)startDate).ToUnixTimeSeconds();
            long period2 = ((DateTimeOffset)endDate).ToUnixTimeSeconds();

            // Yahoo Finance API v8 endpoint with CORS proxy
            // Note: In production, you should use your own backend API to proxy these requests
            string yahooUrl =
                $"https://query1.finance.yahoo.com/v8/finance/chart/{symbol}?period1={period1}&period2={period2}&interval=1d";
            string url = $"https://corsproxy.io/?{Uri.EscapeDataString(yahooUrl)}";

            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to fetch data from Yahoo Finance. Status: {response.StatusCode}");
            }

            string json = await response.Content.ReadAsStringAsync();
            JsonDocument data = JsonDocument.Parse(json);

            JsonElement result = data.RootElement
                .GetProperty("chart")
                .GetProperty("result")[0];

            List<DateTime> timestamps =
            [
                .. result
                    .GetProperty("timestamp")
                    .EnumerateArray()
                    .Select(t => DateTimeOffset.FromUnixTimeSeconds(t.GetInt64()).DateTime)
            ];

            JsonElement quote = result.GetProperty("indicators").GetProperty("quote")[0];
            List<JsonElement> opens = [.. quote.GetProperty("open").EnumerateArray()];
            List<JsonElement> highs = [.. quote.GetProperty("high").EnumerateArray()];
            List<JsonElement> lows = [.. quote.GetProperty("low").EnumerateArray()];
            List<JsonElement> closes = [.. quote.GetProperty("close").EnumerateArray()];
            List<JsonElement> volumes = [.. quote.GetProperty("volume").EnumerateArray()];

            List<StockData> stockData = [];

            for (int i = 0; i < timestamps.Count; i++)
            {
                // Skip entries with null values
                if (opens[i].ValueKind == JsonValueKind.Null ||
                    highs[i].ValueKind == JsonValueKind.Null ||
                    lows[i].ValueKind == JsonValueKind.Null ||
                    closes[i].ValueKind == JsonValueKind.Null ||
                    volumes[i].ValueKind == JsonValueKind.Null)
                {
                    continue;
                }

                stockData.Add(new StockData
                {
                    Date = timestamps[i],
                    Open = Math.Round(opens[i].GetDecimal(), 2),
                    High = Math.Round(highs[i].GetDecimal(), 2),
                    Low = Math.Round(lows[i].GetDecimal(), 2),
                    Close = Math.Round(closes[i].GetDecimal(), 2),
                    Volume = volumes[i].GetInt64()
                });
            }

            return stockData;
        }
        catch (Exception ex)
        {
            // Log the exception in a real application
            Console.WriteLine($"Error fetching data from Yahoo Finance: {ex.Message}");
            throw;
        }
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
}