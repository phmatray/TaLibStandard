using System.Text.Json;
using System.Text.Json.Serialization;

namespace TechnicalAnalysis.Business;

public partial class DataHistoryResponse
{
    [JsonPropertyName("Aggregated")]
    public required bool Aggregated { get; set; }

    [JsonPropertyName("ConversionType")]
    public required ConversionType ConversionType { get; set; }

    [JsonPropertyName("Data")]
    public required List<Candle> Data { get; set; }

    [JsonPropertyName("FirstValueInArray")]
    public required bool FirstValueInArray { get; set; }

    [JsonPropertyName("Response")]
    public required string Response { get; set; }

    [JsonPropertyName("TimeFrom")]
    public required long TimeFrom { get; set; }

    [JsonPropertyName("TimeTo")]
    public required long TimeTo { get; set; }

    [JsonPropertyName("Type")]
    public required long Type { get; set; }
}

public class ConversionType
{
    [JsonPropertyName("conversionSymbol")]
    public required string ConversionSymbol { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }
}

public class Candle
{
    [JsonPropertyName("close")]
    public required double Close { get; set; }

    [JsonPropertyName("high")]
    public required double High { get; set; }

    [JsonPropertyName("low")]
    public required double Low { get; set; }

    [JsonPropertyName("open")]
    public required double Open { get; set; }

    [JsonPropertyName("time")]
    public required long Time { get; set; }

    [JsonPropertyName("volumefrom")]
    public required double Volumefrom { get; set; }

    [JsonPropertyName("volumeto")]
    public required double Volumeto { get; set; }
}

public partial class DataHistoryResponse
{
    public static DataHistoryResponse? FromJson(string json) =>
        JsonSerializer.Deserialize<DataHistoryResponse>(json);
}

public static class Serialize
{
    public static string ToJson(this DataHistoryResponse self) =>
        JsonSerializer.Serialize(self);
}
