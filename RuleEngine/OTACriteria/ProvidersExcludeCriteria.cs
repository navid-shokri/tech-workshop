using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class ProvidersExcludeCriteria: ExcludeCriteria
{
    public ProvidersExcludeCriteria(List<string> values) : base(values)
    {
    }
    public override string GetPropertyName() => "Provider";
}