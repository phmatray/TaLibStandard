using Demo.BlazorWasm.Models;

namespace Demo.BlazorWasm.Services;

public interface IMarketDataService
{
    Task<List<StockData>> GetHistoricalDataAsync(string symbol, int days = 100);
    Task<List<string>> SearchSymbolsAsync(string query);
    List<StockData> GenerateSampleData(int days = 100);
}