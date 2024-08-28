namespace TestRuleEngine;

public class Flight
{
    public string Provider { get; set; }
    public string Airline { get; set; }
    public DateTime DepartureDate { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string Route => $"{Origin}-{Destination}";
    public bool Enable { get; set; } = false;

    public string RuleName { get; set; }
}