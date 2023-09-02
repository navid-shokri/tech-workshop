using Bogus;
using MapsterIntro;

namespace TestProject;

public class FlightBuilder : Faker<Flight>
{
    public FlightBuilder()
    {
        this.Rules((faker, flight) =>
        {
            flight.Airline = faker.PickRandom<string>("IR", "W5", "B9", "TR");
            flight.FlightNo = faker.Random.Number(1200, 1202).ToString();
            flight.Destination = faker.PickRandom("THR", "MHD","KSH");//faker.Address.City();
            flight.Origin = faker.PickRandom("TBZ", "IFN");//faker.Address.City();
            flight.VehicleType = faker.PickRandom("Airbus737", "foker", "md80", "iloshevin");
            flight.AdlPrice = faker.Random.Number(100_000, 1_000_000);
            flight.ChdPrice = faker.Random.Number(100_000, 900_000);
            flight.InfPrice = faker.Random.Number(100_000, 300_000);
            flight.DepartureDate = faker.Date.Between(DateTime.Now, DateTime.Now.AddDays(3));
            flight.FareType = faker.Random.Char('A', 'Z').ToString();
        });
    }
}