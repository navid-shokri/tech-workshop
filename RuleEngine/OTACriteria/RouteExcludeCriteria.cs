using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class RouteExcludeCriteria : ExcludeCriteria
{
    public RouteExcludeCriteria(List<string> values) : base(values)
    {
    }

    public override string GetPropertyName() => "Route";
}