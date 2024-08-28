using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class AgencyIncludeCriteria : IncludeCriteria
{
    public AgencyIncludeCriteria(List<string> agencies) : base(agencies)
    {
        
    }
    public override string GetPropertyName() => "Agency";
}