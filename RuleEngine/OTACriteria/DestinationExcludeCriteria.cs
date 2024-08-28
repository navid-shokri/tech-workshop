using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class DestinationExcludeCriteria :EndsWithCriteria{
    public DestinationExcludeCriteria(string pattern) : base(pattern, true)
    {
    }

    public override string GetPropertyName() => "Route";

}