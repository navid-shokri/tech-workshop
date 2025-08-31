using System.Security.AccessControl;

namespace AuthorizationSample.API;


public class  Person {
    
    public string Name { get; set; }
    public string Family { get; set; }
}

public interface IPersonable
{
    string GetFullName();
}

public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

public enum Weather
{
    Sunny, 
    Cloudy,
    Foggy,
    Rainy,
    Snowy
}