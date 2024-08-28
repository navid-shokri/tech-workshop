using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class DestinationCriteria :EndsWithCriteria{
    public DestinationCriteria(string pattern) : base(pattern)
    {
    }

    public override string GetPropertyName() => "Route";

}