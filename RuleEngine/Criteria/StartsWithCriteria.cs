namespace TestRuleEngine.Criteria;

public abstract class StartsWithCriteria : CriteriaBase
{
    private readonly string _pattern;
    private readonly string expressionResult = "true"; 
    public StartsWithCriteria(string pattern, bool opposite = false)
    {
        if (opposite)
        {
            expressionResult = "false";
        }
        _pattern = pattern;
    }
    public override string GetExpression()
    {
        return GetPropertyName() + ".StartsWith(\"" + _pattern +
               $"\",StringComparison.InvariantCultureIgnoreCase) == {expressionResult}";
    }
}