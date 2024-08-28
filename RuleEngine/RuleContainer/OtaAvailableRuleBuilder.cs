using TestRuleEngine.OTACriteria;

namespace TestRuleEngine.RuleContainer;

public class OtaAvailableRuleBuilder
{
    private OtaAvailableRuleContainer _ruleContainer;
    private AvailableRuleCriteriaArg _arg; 

    public OtaAvailableRuleBuilder(AvailableRuleCriteriaArg arg, string ruleName, string successEvent)
    {
        _arg = arg;
        _ruleContainer = new OtaAvailableRuleContainer(ruleName, successEvent, _arg.Priority);
    }

    public OtaAvailableRuleContainer Build()
    {
        if (_arg.ActivatedFrom.HasValue && _arg.ActivatedTo.HasValue)
            _ruleContainer.AddActivationCriteria(_arg.ActivatedFrom, _arg.ActivatedTo);

        if (_arg.AgenciesExclude.Any())
            _ruleContainer.AddAgencyExcludeCriteria(new AgencyExcludeCriteria(_arg.AgenciesExclude));
        if (_arg.AgenciesInclude.Any())
            _ruleContainer.AddAgencyIncludeCriteria(new AgencyIncludeCriteria(_arg.AgenciesInclude));

        if (_arg.ProvidersExclude.Any())
            _ruleContainer.AddProviderExcludeCriteria(new ProvidersExcludeCriteria(_arg.ProvidersExclude));
        if (_arg.ProvidersInclude.Any())
            _ruleContainer.AddProviderIncludeCriteria(new ProviderIncludeCriteria(_arg.ProvidersInclude));

        if (_arg.AirlinesExclude.Any())
        {
            var groups = _arg.AirlinesExclude.GroupBy(x => x.Type);
            foreach (var group in groups)
            {
                _ruleContainer.AddAirlineExclude(
                    new AirlineExcludeCriteria(group.Key, group.Select(x => x.AirlineCode).ToList()));
            }
        }
        
        if (_arg.AirlinesInclude.Any())
        {
            var groups = _arg.AirlinesInclude.GroupBy(x => x.Type);
            foreach (var group in groups)
            {
                _ruleContainer.AddAirlineInclude(
                    new AirlineIncludeCriteria(group.Key, group.Select(x => x.AirlineCode).ToList()));
            }
        }

        if (_arg.ExcludeRoute.Any())
        {
            var fullRoute = _arg.ExcludeRoute.Where(x =>
                !string.IsNullOrWhiteSpace(x.Origin) && !string.IsNullOrWhiteSpace(x.Destination));
            _ruleContainer.AddRouteExcludeCriteria(
                new RouteExcludeCriteria(fullRoute.Select(x => $"{x.Origin}-{x.Destination}").ToList()));
            
            var originOnly = _arg.ExcludeRoute.Where(x =>
                !string.IsNullOrWhiteSpace(x.Origin) && string.IsNullOrWhiteSpace(x.Destination));
            foreach (var originRoute in originOnly)
            {
                _ruleContainer.AddOriginCriteria(new OriginExcludeCriteria(originRoute.Origin));
            }
            
            var destinationOnly = _arg.ExcludeRoute.Where(x =>
                string.IsNullOrWhiteSpace(x.Origin) && !string.IsNullOrWhiteSpace(x.Destination));
            foreach (var destinationRoute in destinationOnly)
            {
                _ruleContainer.AddOriginCriteria(new DestinationExcludeCriteria(destinationRoute.Destination));
            }
        }
        
        if (_arg.IncludeRoute.Any())
        {
            var fullRoute = _arg.IncludeRoute.Where(x =>
                !string.IsNullOrWhiteSpace(x.Origin) && !string.IsNullOrWhiteSpace(x.Destination));
            _ruleContainer.AddRouteExcludeCriteria(
                new RouteExcludeCriteria(fullRoute.Select(x => $"{x.Origin}-{x.Destination}").ToList()));
            
            var originOnly = _arg.IncludeRoute.Where(x =>
                !string.IsNullOrWhiteSpace(x.Origin) && string.IsNullOrWhiteSpace(x.Destination));
            foreach (var originRoute in originOnly)
            {
                _ruleContainer.AddOriginCriteria(new OriginCriteria(originRoute.Origin));
            }
            
            var destinationOnly = _arg.IncludeRoute.Where(x =>
                string.IsNullOrWhiteSpace(x.Origin) && !string.IsNullOrWhiteSpace(x.Destination));
            foreach (var destinationRoute in destinationOnly)
            {
                _ruleContainer.AddOriginCriteria(new OriginCriteria(destinationRoute.Destination));
            }
        }

        return _ruleContainer;
        
    }
}