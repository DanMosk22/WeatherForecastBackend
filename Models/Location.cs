namespace Weather.Models;

public class Location
{
    public int Id { get; set; }
    public float Lat { get; set; }
    public float Lon { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public List<Forecast> Forecasts { get; set; } = new();
}