namespace TestRuleEngine.Criteria;

public abstract class DateCriteria : CriteriaBase
{
    private string? startDate;
    private string? endDate;
    private readonly bool _includeEquals;

    public DateCriteria(DateTime? start, DateTime? end, bool includeEquals = true)
    {
        startDate = start?.ToString();
        endDate = end?.ToString();
        _includeEquals = includeEquals;
    }
    
    public override string GetExpression()
    {
        var expression = "";
        if (startDate != null)
        {
            expression += GetPropertyName() + graterThan(_includeEquals) + "DateTime.Parse(\""+startDate+"\")";
        }

        if (!string.IsNullOrWhiteSpace(expression))
        {
            expression += " AND ";
        }

        if (endDate != null)
        {
            expression += GetPropertyName() + lessThan(_includeEquals) + "DateTime.Parse(\""+endDate+"\")";
        }

        return expression;
    }

    private string graterThan(bool includeEquals = true)
    {

        return $" >" + (includeEquals ? "=" : "");
    }

    private string lessThan(bool includeEquals = true)
    {

        return $" <" + (includeEquals ? "=" : "");
    }
}