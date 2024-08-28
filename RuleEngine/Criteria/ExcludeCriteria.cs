namespace TestRuleEngine.Criteria;

public abstract class ExcludeCriteria : CriteriaBase
{
    private List<string> _values = new List<string>();

    public ExcludeCriteria(List<string> values)
    {
        _values = values;
    }
    public override string GetExpression()
    {
        return "CustomRuleFilter.CheckContains("+GetPropertyName()+", \""+ string.Join(",", _values)+"\") != true";
    }
    
}