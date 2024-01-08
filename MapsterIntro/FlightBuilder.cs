namespace MapsterIntro;

public partial class Flight 
{
    public class FlightBuilder : IFlightBuilder, IFlightBuilderPricing, IFlightBuilderInfo
    {
        private Flight flight;
        internal FlightBuilder()
        {
            flight = new Flight();
        }
         
        public IFlightBuilderPricing SetBaseInfo(string origin, string destination, DateTime departure, string airline)
        {
            flight.Origin = origin;
            flight.Destination = destination;
            flight.DepartureDate = departure;
            flight.Airline = airline;
            return this;
        }

        public IFlightBuilderInfo SetPricing(long adlPrice, long chdPrice, long infPrice)
        {
            flight.AdlPrice = adlPrice;
            flight.ChdPrice = chdPrice;
            flight.InfPrice = infPrice;
            return this;
        }

        public IFlightBuilderInfo SetFlightNo(string flightNumber)
        {
            flight.FlightNo = flightNumber;
            return this;
        }

        public IFlightBuilderInfo SetFareType(string fareType)
        {
            flight.FareType = fareType;
            return this;
        }

        public IFlightBuilderInfo SetVehicleType(string vehicleType)
        {
            flight.VehicleType = vehicleType;
            return this;
        }

        public Flight Build()
        {
            flight.ValidateRules();
            return flight;
        }
    }
}