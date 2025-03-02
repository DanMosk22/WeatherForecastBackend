using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Weather.Data;
using Weather.Models;
using Weather.Services;

namespace Weather.Controllers;

[ApiController]
[Route("api/forecast")]
public class ForecastController : ControllerBase{
    private readonly ForecastDAO forecastDAO;

    public ForecastController(ForecastDAO _forecastDAO)
    {
        this.forecastDAO = _forecastDAO;
    }

    [HttpPost("prognosisForLocation")]
    public async Task<ActionResult<object>> PrognosisForLocation([FromBody] JsonDocument locationJson){
        Location location = new(locationJson);
        var prognosis = await ForecastService.GetPrognosis(location);

        return Ok(prognosis);

    }

    [HttpPost("historyForLocation")]
    public async Task<ActionResult<Location>> HistoryForLocation([FromBody] JsonDocument locationJson)
    {
        Location location = new(locationJson);
        DateOnly endDate = DateOnly.FromDateTime(DateTime.Now).AddDays(-1);
        DateOnly startDate = endDate.AddDays(-6);

        var history = await ForecastService.GetHistory(location, startDate, endDate);

        // save the history to database in a separate thread
        _ = Task.Run(async() =>
        {
            var loc = await forecastDAO.GetOrCreateLocationAsync(location);
            var dailyTime = history.RootElement.GetProperty("daily").GetProperty("time");
            var dailyMaxTemp = history.RootElement.GetProperty("daily").GetProperty("temperature_2m_max");
            var dailyMinTemp = history.RootElement.GetProperty("daily").GetProperty("temperature_2m_min");

            for (int i = 0; i < dailyTime.GetArrayLength(); i++)
            {
                string? date = dailyTime[i].GetString();
                float maxTemp = (float)dailyMaxTemp[i].GetDouble();
                float minTemp = (float)dailyMinTemp[i].GetDouble();

                Forecast f = new(date, minTemp, maxTemp, loc.Id);

                forecastDAO.SaveForecastHistory(f);

            }

        });

        return Ok(history);
    }

    private async void save(Location location)
    {
        await forecastDAO.GetOrCreateLocationAsync(location);   
    }
}