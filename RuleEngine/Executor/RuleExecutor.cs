using RulesEngine.Extensions;
using RulesEngine.Models;

namespace TestRuleEngine.Executor;

public class RuleExecutor
{
    private readonly string _workflowName;
    private readonly RulesEngine.RulesEngine _rulesEngine; 
    public RuleExecutor(List<RuleContainerBase> containers, string workflowName, ReSettings? setting = null) 
    {
        _workflowName = workflowName;
        var workflow = new Workflow();
        workflow.WorkflowName = workflowName;
        workflow.Rules = containers.Select(x => x.CompileRule()).ToList();
        _rulesEngine = new RulesEngine.RulesEngine(new Workflow[]{workflow}, setting);
    }


    public async Task<List<T>> ExecuteAsync<T>(List<T> items, Action<T, string> successCallBack)
    {
        foreach (var item in items)
        {
            var applyResult = await _rulesEngine.ExecuteAllRulesAsync(_workflowName, 
                new RuleParameter("item", item));
            applyResult.OnSuccess(name =>
            {
                successCallBack(item, name);
            });
        }

        return items;
    }
    
    public async Task<List<T>> FilterByRuleAsync<T>(List<T> items)
    {
        var output = new List<T>();
        foreach (var item in items)
        {
            var applyResult = await _rulesEngine.ExecuteAllRulesAsync(_workflowName, 
                new RuleParameter("item", item));
            applyResult.OnSuccess(name =>
            {
               output.Add(item);
            });
        }

        return output;
    }
}