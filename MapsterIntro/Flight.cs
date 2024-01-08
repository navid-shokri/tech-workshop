
namespace MapsterIntro;

public partial class Flight
{
    protected Flight()
    {
    }

    protected Flight(string origin, string destination, DateTime departureDate, string flightNo, string airline,
        string vehicleType, string fareType, long adlPrice, long chdPrice, long infPrice)
    {
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
        FlightNo = flightNo;
        Airline = airline;
        VehicleType = vehicleType;
        FareType = fareType;
        AdlPrice = adlPrice;
        ChdPrice = chdPrice;
        InfPrice = infPrice;
        ValidateRules();
    }

    private void ValidateRules()
    {
        if (Origin.Length < 3)
        {
            throw new Exception("invalid origin");
        }

        if (Destination.Length < 3)
        {
            throw new Exception("invalid destination");
        }

        if (DepartureDate < DateTime.Now)
        {
            throw new Exception("invalid date");
        }
    }


    public string FlightUID() => $"{Origin}:{Destination}:{DepartureDate:yyyyMMdd}:{FlightNo}{Airline}";
    public string Origin { get; private set; }
    public string Destination { get; private set; }
    public DateTime DepartureDate { get; private set; }
    public string FlightNo { get; private set; }
    public string Airline { get; private set; }
    public string VehicleType { get; private set; }
    public string FareType { get; private set; }
    public long AdlPrice { get; private set; }
    public long ChdPrice { get; private set; }
    public long InfPrice { get; private set; }

    public static IFlightBuilder GetBuilder()
    {
        return new FlightBuilder();
    }
}