namespace TestRuleEngine.Criteria;

public abstract class LessThanCriteria : CriteriaBase
{
    private readonly string _value;
    private readonly bool _includeEquals;

    public LessThanCriteria(string value, bool includeEquals)
    {
        _value = value;
        _includeEquals = includeEquals;
    }
    public override string GetExpression()
    {
        return GetPropertyName() + lessThan(_includeEquals)  + _value;
    }
    
    private string lessThan(bool includeEquals = true)
    {

        return $" <" + (includeEquals ? "=" : "");
    }
    
}