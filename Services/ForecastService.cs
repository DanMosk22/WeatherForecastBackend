using Weather.Models;
using System.Text.Json;

namespace Weather.Services;


public class ForecastService{

    public static async Task<JsonDocument> GetPrognosis(Location location){
        using(HttpClient client = new()){
            client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");
            var prognosis = await client.GetAsync($"forecast?latitude={location.Lat}&longitude={location.Lon}&current=temperature_2m&daily=temperature_2m_max,temperature_2m_min");
            prognosis.EnsureSuccessStatusCode();

            return JsonDocument.Parse(prognosis.Content.ReadAsStringAsync().Result);
        }
    }

    public static async Task<JsonDocument> GetHistory(Location location, DateOnly startDate, DateOnly endDate){
        using(HttpClient client = new()){
            client.BaseAddress = new Uri("https://historical-forecast-api.open-meteo.com/v1/");
            var history = await client.GetAsync($"forecast?latitude={location.Lat}&longitude={location.Lon}&start_date={startDate}&end_date={endDate}&daily=temperature_2m_max,temperature_2m_min");
            history.EnsureSuccessStatusCode();

            return JsonDocument.Parse(history.Content.ReadAsStringAsync().Result);
        }

    }

}