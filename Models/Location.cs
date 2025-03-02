using System.Text.Json;

namespace Weather.Models;

public class Location
{
    public Location() { }
    public Location(JsonDocument json){
        var location = json.RootElement;
        Lat = (float)location.GetProperty("lat").GetDouble();
        Lon = (float)location.GetProperty("lon").GetDouble();
        Country = location.GetProperty("country").GetString();
        City = location.GetProperty("city").GetString();
    }

    public int Id { get; set; }
    public float Lat { get; set; }
    public float Lon { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public List<Forecast> Forecasts { get; set; } = new();
}