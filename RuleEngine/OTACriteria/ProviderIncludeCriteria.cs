using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class ProviderIncludeCriteria : IncludeCriteria
{
    public ProviderIncludeCriteria(List<string> values) : base(values)
    {
    }

    public override string GetPropertyName() => "Provider";
}