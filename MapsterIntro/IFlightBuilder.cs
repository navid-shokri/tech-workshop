namespace MapsterIntro;

public interface IFlightBuilder 
{
    IFlightBuilderPricing SetBaseInfo(string origin, string destination, DateTime departure, string airline);
    Flight Build();
}

public interface IFlightBuilderPricing
{
    IFlightBuilderInfo SetPricing(long adlPrice, long chdPrice, long infPrice);
    Flight Build();
}

public interface IFlightBuilderInfo 
{
    IFlightBuilderInfo SetFlightNo(string flightNumber);
    IFlightBuilderInfo SetFareType(string fareType);
    IFlightBuilderInfo SetVehicleType(string vehicleType);
    Flight Build();
}