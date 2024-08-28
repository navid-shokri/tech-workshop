using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class RouteIncludeCriteria : IncludeCriteria
{
    public RouteIncludeCriteria(List<string> routes) : base(routes)
    {
        
    }

    public override string GetPropertyName() => "Route";
}