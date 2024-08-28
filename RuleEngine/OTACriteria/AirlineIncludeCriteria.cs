using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class AirlineIncludeCriteria: IncludeCriteria
{
    private AirlineType _type;
    public AirlineIncludeCriteria(AirlineType type,List<string> airLines) : base(airLines)
    {
        _type = type;
    }

    public override string GetPropertyName() =>
        _type == AirlineType.Markrting ? "MarketingAirline" : "OperatingAirLine";
}

public enum AirlineType
{
    Markrting,
    Operationg
}