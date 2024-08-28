namespace TestRuleEngine.Criteria;

public abstract class IncludeCriteria : CriteriaBase
{
    private List<string> _values = new List<string>();

    public IncludeCriteria(List<string> values)
    {
        _values = values;
    }
    public override string GetExpression()
    {
        return "CustomRuleFilter.CheckContains("+GetPropertyName()+", \""+ string.Join(",", _values)+"\") == true";
    }
    
}