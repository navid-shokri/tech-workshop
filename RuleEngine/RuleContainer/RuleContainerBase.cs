using RulesEngine.Models;
using TestRuleEngine.Criteria;

namespace TestRuleEngine;

public abstract class RuleContainerBase 
{
    public RuleContainerBase(string ruleName, string successEvent, int priority)
    {
        Priority = priority;
        RuleName = ruleName;
        SuccessEvent = successEvent;
        Criteries = new List<CriteriaBase>();
    }

    protected int Priority { get; set; }
    protected string RuleName { get; private set; }
    protected string SuccessEvent { get; private set; }
    protected string ErrorMessage { get; private set; }
    protected string ErrorType { get; private set; }

    public List<CriteriaBase> Criteries { get; private set; }

    protected void AddCriteria(CriteriaBase criteria)
    {
        Criteries.Add(criteria);
    }
   
    
    public RuleContainerBase SetErrorMessage(string errorMessage)
    {
        ErrorMessage = errorMessage;
        return this;
    }

    public RuleContainerBase SetErrorType(string errorType)
    {
        ErrorType = errorType;
        return this;
    }

    protected virtual string GenerateExpression()
    {
        return string.Join(" AND ", Criteries.Select(x => x.GetExpression()));
    }
    
    public virtual Rule CompileRule()
    {
        return new Rule
        {
            Enabled = true,
            RuleName = this.RuleName,
            SuccessEvent = this.SuccessEvent,
            RuleExpressionType = RuleExpressionType.LambdaExpression,
            Expression = GenerateExpression(),
            LocalParams = Criteries.SelectMany(x=>x.GetLocalParameters()).ToList()
        };
    }
}