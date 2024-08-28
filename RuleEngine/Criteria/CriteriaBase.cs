using RulesEngine.Models;

namespace TestRuleEngine.Criteria;

public abstract class CriteriaBase
{
    public abstract string GetExpression();
    public abstract string GetPropertyName();

    public virtual List<LocalParam> GetLocalParameters()
    {
        return new List<LocalParam>();
    }
}