// See https://aka.ms/new-console-template for more information

using Bogus;
using RulesEngine.Extensions;
using RulesEngine.Models;
using TestRuleEngine;

Console.WriteLine("Hello, World!");
var faker = new Faker<Customer>();
faker = faker.RuleFor(x => x.Name, (f, customer) => f.Name.FullName())
    .RuleFor(x => x.BirthDay, (f, customer) => f.Person.DateOfBirth)
    .RuleFor(x => x.Balance, (f, customer) => f.Random.Int(20,1000))
    .RuleFor(x => x.Address,
    (f, customer) => new Address { SreetAddress = f.Address.StreetAddress(), City = f.Address.City() });
var customers =faker.GenerateBetween(5,15);

var rule1 = new Rule
{
    RuleName = "UnderAge",
    Enabled = true,
    Expression = "Age < 18",
    RuleExpressionType = RuleExpressionType.LambdaExpression,
    SuccessEvent = "10",
    //Operator = "fuck you all",
    Actions = new RuleActions
    {
        OnSuccess = new ActionInfo
        {
            Name = "OutputExpression",
            Context = new Dictionary<string, object>
            {
                { "Expression", "\"hooray\"" }
            }
        }
    }
};

var rule2 = new Rule
{
    RuleName = "EnoughBalance",
    Enabled = true,
    Expression = "Balance > 1",
    RuleExpressionType = RuleExpressionType.LambdaExpression,
    SuccessEvent = "20",
    Actions = new RuleActions
    {
        OnSuccess = new ActionInfo
        {
            Name = "EvaluateRule",
            Context = new Dictionary<string, object>
            {
                { "Expression", "Message += \":)\"" }
            }
        },
    }
};
var rules = new List<Rule>();
rules.Add(rule1);
rules.Add(rule2);
var workFlow = new Workflow();
workFlow.WorkflowName = "test";
workFlow.Rules = rules;

var ruleEngine = new RulesEngine.RulesEngine(new Workflow[]{workFlow}.ToArray());

var t = await ruleEngine.ExecuteAllRulesAsync("test",
    new RuleParameter("item", customers.FirstOrDefault()));

foreach (var ti in t)
{
    
}
t.OnSuccess(name =>
{ 
    Console.WriteLine($"WTF? {name}");
});
