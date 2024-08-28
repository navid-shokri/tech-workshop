using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class SaleDateCriteria : DateTimeNowCriteria
{
    public SaleDateCriteria(DateTime? start, DateTime? end, bool includeEquals = true) : base(start, end, includeEquals)
    {
    }
}