using RulesEngine.Models;

namespace TestRuleEngine.Criteria;

public abstract class DateTimeNowCriteria :DateCriteria
{
    protected DateTimeNowCriteria(DateTime? start, DateTime? end, bool includeEquals = true) : base(start, end, includeEquals)
    {
    }
    public override string GetPropertyName()
    {
        return "DateTimeNow";
    }

    public override List<LocalParam> GetLocalParameters()
    {
        return new List<LocalParam>()
        {
            new LocalParam
            {
                Name = "DateTimeNow",
                Expression = "DateTime.Parse(\""+DateTime.Now.ToString()+"\")"
            }
        };
    }

    
}