namespace GLPM.TechnicalAnalysis.Business
{
    using System.Collections.Generic;
    using System.Globalization;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class DataHistoryResponse
    {
        [JsonProperty("Aggregated")]
        public bool Aggregated { get; set; }

        [JsonProperty("ConversionType")]
        public ConversionType ConversionType { get; set; }

        [JsonProperty("Data")]
        public List<Candle> Data { get; set; }

        [JsonProperty("FirstValueInArray")]
        public bool FirstValueInArray { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }

        [JsonProperty("TimeFrom")]
        public long TimeFrom { get; set; }

        [JsonProperty("TimeTo")]
        public long TimeTo { get; set; }

        [JsonProperty("Type")]
        public long Type { get; set; }
    }

    public partial class ConversionType
    {
        [JsonProperty("conversionSymbol")]
        public string ConversionSymbol { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Candle
    {
        [JsonProperty("close")]
        public double Close { get; set; }

        [JsonProperty("high")]
        public double High { get; set; }

        [JsonProperty("low")]
        public double Low { get; set; }

        [JsonProperty("open")]
        public double Open { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("volumefrom")]
        public double Volumefrom { get; set; }

        [JsonProperty("volumeto")]
        public double Volumeto { get; set; }
    }

    public partial class DataHistoryResponse
    {
        public static DataHistoryResponse FromJson(string json) =>
            JsonConvert.DeserializeObject<DataHistoryResponse>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DataHistoryResponse self) =>
            JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal class Converter
    {
        public static readonly JsonSerializerSettings Settings =
            new JsonSerializerSettings
                {
                    MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                    DateParseHandling = DateParseHandling.None,
                    Converters =
                        {
                            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                        }
                };
    }
}