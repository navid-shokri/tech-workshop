using RulesEngine.Models;
using TestRuleEngine.OTACriteria;

namespace TestRuleEngine;

public class OtaAvailableRuleContainer : RuleContainerBase
{
    public OtaAvailableRuleContainer(string ruleName, string successEvent, int priority) : base(ruleName, successEvent, priority)
    {
       
    }

    public OtaAvailableRuleContainer AddOriginCriteria(OriginCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }
    
    public OtaAvailableRuleContainer AddDestinationCriteria(DestinationCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }

    public OtaAvailableRuleContainer AddProviderIncludeCriteria(ProviderIncludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }
    public OtaAvailableRuleContainer AddProviderExcludeCriteria(ProvidersExcludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }

    public OtaAvailableRuleContainer AddAgencyIncludeCriteria(AgencyIncludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }
    public OtaAvailableRuleContainer AddAgencyExcludeCriteria(AgencyExcludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }

    public OtaAvailableRuleContainer AddRouteIncludeCriteria(RouteIncludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }
    public OtaAvailableRuleContainer AddRouteExcludeCriteria(RouteExcludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }

    public OtaAvailableRuleContainer AddAirlineInclude(AirlineIncludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }

    public OtaAvailableRuleContainer AddAirlineExclude(AirlineExcludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }


    public OtaAvailableRuleContainer AddActivationCriteria(DateTime? startDate, DateTime? endDate)
    {
        AddCriteria(new ActivationRuleCriteria(startDate, endDate));
        return this;
    }


    public OtaAvailableRuleContainer AddOriginCriteria(OriginExcludeCriteria criteria)
    {
       AddCriteria(criteria);
       return this;
    }

    public OtaAvailableRuleContainer AddOriginCriteria(DestinationExcludeCriteria criteria)
    {
        AddCriteria(criteria);
        return this;
    }
}