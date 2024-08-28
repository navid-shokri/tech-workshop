namespace TestRuleEngine.Criteria;

public abstract class GreaterThanCriteria : CriteriaBase
{
    private string _value;
    private readonly bool _includeEqual;

    public GreaterThanCriteria(string value, bool includeEqual)
    {
        _value = value;
        _includeEqual = includeEqual;
    }
    public override string GetExpression()
    {
        return GetPropertyName() + greaterThan(_includeEqual) + _value;
    }

    private string greaterThan(bool includeEquals = true)
    {

        return $" >" + (includeEquals ? "=" : "");
    }
    
}