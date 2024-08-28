using RulesEngine.Models;
using TestRuleEngine.Criteria;

namespace TestRuleEngine.OTACriteria;

public class ActivationRuleCriteria : DateTimeNowCriteria
{
    public ActivationRuleCriteria(DateTime? start, DateTime? end) : base(start, end, true)
    {
    }   
    
}