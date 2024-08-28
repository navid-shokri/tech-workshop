using TestRuleEngine.Criteria;

namespace TestRuleEngine.RuleContainer;

public class DirectionIncludeCriteria : IncludeCriteria
{
    public DirectionIncludeCriteria(List<string> values) : base(values)
    {
    }

    public override string GetPropertyName() => "Direction";
}