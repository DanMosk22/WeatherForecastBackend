using Microsoft.EntityFrameworkCore;
using Weather.Models;

namespace Weather.Data;


public class ForecastDAO{

    private readonly IServiceScopeFactory _scopeFactory;

    public ForecastDAO(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    private AppDbContext GetDBContext(){
        var scope = _scopeFactory.CreateScope();
        return scope.ServiceProvider.GetRequiredService<AppDbContext>();
    }

    public async Task<Location> GetOrCreateLocationAsync(Location newLocation)
    {
        var _db = GetDBContext();
        // check if record exists
        var existingLocation = await _db.Locations
            .FirstOrDefaultAsync(l => l.Lat == newLocation.Lat && l.Lon == newLocation.Lon);

        if (existingLocation != null){
            return existingLocation; // return if exists
        }

        // create if doesnt exist
        _db.Locations.Add(newLocation);
        await _db.SaveChangesAsync();

        return newLocation;
    }

    public async void SaveForecastHistory(Forecast forecast){
        var _db = GetDBContext();
        try{
            _db.Forecasts.Add(forecast);
            await _db.SaveChangesAsync();
        } catch (DbUpdateException ex) {
            if (ex.InnerException?.Message.ToLower().Contains("duplicate") == true)
            {
                Console.WriteLine("Record already exists");
            }
        }
    }
}