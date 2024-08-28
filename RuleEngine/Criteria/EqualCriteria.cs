namespace TestRuleEngine.Criteria;

public abstract class EqualCriteria : CriteriaBase
{
    private readonly string _value;

    public EqualCriteria(string value)
    {
        _value = value;
    }
    public override string GetExpression()
    {
        return GetPropertyName() + "=="+_value;
    }
}