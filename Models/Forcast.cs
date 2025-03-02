namespace Weather.Models;

public class Forecast{

    public Forecast(){}

    public Forecast(string date, float minTemp, float maxTemp, int locationId){
        this.Date = DateOnly.Parse(date);
        this.MinTemp = minTemp;
        this.MaxTemp = maxTemp;
        this.LocationID = locationId;
    }
    public int Id { get; set; }
    public DateOnly  Date { get; set; }
    public float MinTemp { get; set; }
    public float MaxTemp { get; set; }
    public int LocationID { get; set; }
    public Location Location { get; set; } = null!;
    
}