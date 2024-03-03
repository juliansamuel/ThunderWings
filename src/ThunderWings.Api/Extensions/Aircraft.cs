using System.Text.Json.Serialization;

namespace ThunderWings.Api.Extensions;

public class Aircraft
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("topSpeed")]
    public decimal TopSpeed { get; set; }

    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("manufacturer")]
    public string Manufacturer { get; set; }

    [JsonPropertyName("role")]
    public string ProductRole { get; set; }
}