using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class OriginExcludeCriteria : StartsWithCriteria 
{

    public OriginExcludeCriteria(string pattern) : base(pattern, true)
    {
    }

    public override string GetPropertyName() => "Route";
}