using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TechnicalAnalysis.Business;

public partial class DataHistoryResponse
{
    [JsonPropertyName("Aggregated")]
    public bool Aggregated { get; set; }

    [JsonPropertyName("ConversionType")]
    public ConversionType ConversionType { get; set; }

    [JsonPropertyName("Data")]
    public List<Candle> Data { get; set; }

    [JsonPropertyName("FirstValueInArray")]
    public bool FirstValueInArray { get; set; }

    [JsonPropertyName("Response")]
    public string Response { get; set; }

    [JsonPropertyName("TimeFrom")]
    public long TimeFrom { get; set; }

    [JsonPropertyName("TimeTo")]
    public long TimeTo { get; set; }

    [JsonPropertyName("Type")]
    public long Type { get; set; }
}

public partial class ConversionType
{
    [JsonPropertyName("conversionSymbol")]
    public string ConversionSymbol { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }
}

public partial class Candle
{
    [JsonPropertyName("close")]
    public double Close { get; set; }

    [JsonPropertyName("high")]
    public double High { get; set; }

    [JsonPropertyName("low")]
    public double Low { get; set; }

    [JsonPropertyName("open")]
    public double Open { get; set; }

    [JsonPropertyName("time")]
    public long Time { get; set; }

    [JsonPropertyName("volumefrom")]
    public double Volumefrom { get; set; }

    [JsonPropertyName("volumeto")]
    public double Volumeto { get; set; }
}

public partial class DataHistoryResponse
{
    public static DataHistoryResponse FromJson(string json) =>
        JsonSerializer.Deserialize<DataHistoryResponse>(json);
}

public static class Serialize
{
    public static string ToJson(this DataHistoryResponse self) =>
        JsonSerializer.Serialize(self);
}
