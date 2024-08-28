using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class AgencyExcludeCriteria: ExcludeCriteria
{
    public AgencyExcludeCriteria(List<string> values) : base(values)
    {
    }

    public override string GetPropertyName() => "Agency";
}