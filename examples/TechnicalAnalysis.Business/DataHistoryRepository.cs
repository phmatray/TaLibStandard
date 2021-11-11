using System.Net.Http.Headers;

namespace TechnicalAnalysis.Business
{
    public static class DataHistoryRepository
    {
        public static DataHistory GetDataHistoryFromFile(string fromSymbol, string toSymbol, string interval)
        {
            string[] paths = {AppContext.BaseDirectory, "Data", $"{fromSymbol}-{toSymbol}-{interval}.json"};
            string fullPath = Path.Combine(paths);
            
            var jsonRaw = File.ReadAllText(fullPath);
            var dataHistory = ParseJson(jsonRaw);
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

            var endpoint = $@"https://min-api.cryptocompare.com/data/histo{interval}?fsym={fromSymbol.ToUpper()}&tsym={toSymbol.ToUpper()}&limit={limit}&aggregate=1&e=CCCAGG";
            var jsonRaw = client.GetStringAsync(endpoint).GetAwaiter().GetResult();
            var dataHistory = ParseJson(jsonRaw);
            return dataHistory;
        }

        private static DataHistory ParseJson(string jsonRaw)
        {
            var histoResponse = DataHistoryResponse.FromJson(jsonRaw);

            if (histoResponse.Response != "Success")
            {
                throw new Exception("Couldn't create the data hist");
            }

            var candles = histoResponse.Data;
            return new DataHistory(candles);
        }
    }
}
