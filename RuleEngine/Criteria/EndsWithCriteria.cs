namespace TestRuleEngine.Criteria;

public abstract class EndsWithCriteria : CriteriaBase
{
    private readonly string _pattern;
    private readonly string expressionResult = "true";
    public EndsWithCriteria(string pattern, bool opposite = false)
    {
        if (opposite)
            expressionResult = "false";
        _pattern = pattern;
    }
    public override string GetExpression()
    {
        return GetPropertyName()+".EndsWith(\""+ _pattern+$"\",StringComparison.InvariantCultureIgnoreCase) == {expressionResult}";
    }
}