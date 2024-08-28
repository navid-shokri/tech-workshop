namespace TestRuleEngine.Criteria;

public abstract class StringEqualCriteria : CriteriaBase
{
    private readonly string _value;

    public StringEqualCriteria(string value)
    {
        _value = value;
    }
    public override string GetExpression()
    {
        return GetPropertyName() + ".Equals(\""+_value+"\", StringComparison.InvariantCultureIgnoreCase)";
    }
}