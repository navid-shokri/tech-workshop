namespace TestRuleEngine;

public class AvailableRuleCriteriaArg
{
    public DateTime? ActivatedFrom { get; set; }
    public DateTime? ActivatedTo { get; set; }
    
    public string Title { get; set; }
    public RuleType Type { get; set; }
    public int Priority { get; set; }
    public string DirectionsInclude { get; set; }
    public bool UseWithOther { get; set; }
    public List<string> ProvidersInclude { get; set; }
    public List<string> ProvidersExclude { get; set; }
    public List<string> AgenciesInclude { get; set; }
    public List<string> AgenciesExclude { get; set; }
    public List<string> MembersInclude { get; set; }
    public List<string> MembersExclude { get; set; }
    public List<Route> IncludeRoute { get; set; }
    public List<Route> ExcludeRoute { get; set; }
    public List<Airline> AirlinesInclude { get; set; }
    public List<Airline> AirlinesExclude { get; set; }
    public List<DateTime> IncludeTravelDate { get; set; }
    public List<DateTime> ExcludeTravelDate { get; set; }
    public List<DateTime> IncludeSaleDate { get; set; }
    public List<DateTime> ExcludeSaleDate { get; set; }
    


}