using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class OriginCriteria : StartsWithCriteria
{
    public OriginCriteria(string pattern) : base(pattern)
    {
    }

    public override string GetPropertyName() => "Route";
}