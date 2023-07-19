using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace TechnicalAnalysis.Business;

public static class DataHistoryRepository
{
    public static DataHistory GetDataHistoryFromFile(string fromSymbol, string toSymbol, string interval)
    {
        string[] paths = {AppContext.BaseDirectory, "Data", $"{fromSymbol}-{toSymbol}-{interval}.json"};
        string fullPath = Path.Combine(paths);
            
        string jsonRaw = File.ReadAllText(fullPath);
        DataHistory dataHistory = ParseJson(jsonRaw);
        return dataHistory;
    }

    public static DataHistory GetDataHistoryFromService(string fromSymbol, string toSymbol, string interval, int limit = 500)
    {
        if (!new[] { "day", "hour", "minute" }.Contains(interval))
        {
            throw new ArgumentOutOfRangeException(nameof(interval), interval, null);
        }

        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        client.DefaultRequestHeaders.Add("User-Agent", "TechnicalAnalysis");

        string endpoint = $@"https://min-api.cryptocompare.com/data/histo{interval}?fsym={fromSymbol.ToUpper()}&tsym={toSymbol.ToUpper()}&limit={limit}&aggregate=1&e=CCCAGG";
        string jsonRaw = client.GetStringAsync(endpoint).GetAwaiter().GetResult();
        DataHistory dataHistory = ParseJson(jsonRaw);
        return dataHistory;
    }

    private static DataHistory ParseJson(string jsonRaw)
    {
        DataHistoryResponse? dataHistoryResponse = DataHistoryResponse.FromJson(jsonRaw);

        if (dataHistoryResponse?.Response != "Success")
        {
            throw new JsonException("Couldn't create the data history");
        }

        List<Candle> candles = dataHistoryResponse.Data;
        return new DataHistory(candles);
    }
}
