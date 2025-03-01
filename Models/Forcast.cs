namespace Weather.Models;

public class Forecast{

    public int Id { get; set; }
    public DateOnly  Date { get; set; }
    public float MinTemp { get; set; }
    public float MaxTemp { get; set; }
    public int LocationID { get; set; }
    public Location Location { get; set; } = null!;
    
}