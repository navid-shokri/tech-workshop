using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class DepartureDateCriteria : DateCriteria
{
    public DepartureDateCriteria(DateTime? start, DateTime? end, bool includeEquals = true) : base(start, end, includeEquals)
    {
    }

    public override string GetPropertyName() => "DepartureDate";
}