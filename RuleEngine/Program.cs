// See https://aka.ms/new-console-template for more information

using Bogus;
using RE.HelperFunctions;
using RulesEngine.Extensions;
using RulesEngine.Models;
using TestRuleEngine;
using TestRuleEngine.Executor;
using TestRuleEngine.OTACriteria;

Console.WriteLine("Hello, World!");
var faker = new Faker<Flight>();
faker = faker.RuleFor(x => x.Destination, 
        (f, customer) => f.Random.ListItem(new List<string>
        {
            "MHD", "THR", "BND", "SRY"
        }))
    .RuleFor(x => x.Origin, (f, customer) => f.Random.ListItem(new List<string>
    {
        "MHD", "THR", "BND", "SRY"
    })).RuleFor(x=>x.Provider , (f, fl) =>f.Random.ListItem(new List<string>
    {
        "Parto", "ITours", "FlyBaghdad","Avtra"
    }))
    .RuleFor(x => x.Airline, (f, customer) => f.Random.ListItem(new List<string>{"IR", "W5", "Y9", "I3"}))
    .RuleFor(x => x.DepartureDate,
    (f, customer) => f.Date.Soon());
var flights =faker.GenerateBetween(5,8);    
var fromMashhadRule = new OtaAvailableRuleContainer("From_Mashhad", "10",1);
fromMashhadRule.AddOriginCriteria(new OriginCriteria("MHD"));


var toBandarRule = new OtaAvailableRuleContainer("To_Bandar", "20",2);
toBandarRule.AddDestinationCriteria(new DestinationCriteria("BND"));

var PartoAndAvtraOnly = new OtaAvailableRuleContainer("parto_avtra", "50",3);
PartoAndAvtraOnly.AddProviderIncludeCriteria(new ProviderIncludeCriteria(new List<string> { "Parto", "Avtra" }));

var ActivationRule = new OtaAvailableRuleContainer("activation_rule", "100",4);
ActivationRule.AddActivationCriteria(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));
/*var rule3 = new Rule
{
    RuleName = "ExistIn",
    Enabled = true,
    Expression = "Airline.CheckContains(\"W5,IR\")",
    RuleExpressionType = RuleExpressionType.LambdaExpression,
    SuccessEvent = "30",
    Actions = new RuleActions
    {
        OnSuccess = new ActionInfo
        {
            Name = "OutputExpression",
            Context = new Dictionary<string, object>
            {
                { "Expression", "\"hooray\"" }
            },
        }
    }
};
var rule1 = new Rule
{
    RuleName = "From_Mashhad",
    Enabled = true,
    Expression = "Origin.Equals(\"MHD\", StringComparison.InvariantCultureIgnoreCase)",
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
    RuleName = "To_bandar",
    Enabled = true,
    //Expression = "Destination.Equals(\"MHD\", StringComparison.InvariantCultureIgnoreCase)",
    Expression = "Destination.ToUpper()==\"BND\"",
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
};*/
/*
var rules = new List<Rule>();

rules.Add(toBandarRule.CompileRule());
rules.Add(fromMashhadRule.CompileRule());
rules.Add(PartoAndAvtraOnly.CompileRule());
rules.Add(ActivationRule.CompileRule());
*/


/*rules.Add(rule1);
rules.Add(rule2);*/
/*var workFlow = new Workflow();
workFlow.WorkflowName = "test";
workFlow.Rules = rules;*/
var setting = new ReSettings { CustomTypes = new Type[] { typeof(CustomRuleFilter) } };
var ruleExecutor = new RuleExecutor(new List<RuleContainerBase>
{
    toBandarRule,fromMashhadRule,PartoAndAvtraOnly
}, "MyWorkflow", setting);
await ruleExecutor.ExecuteAsync(flights, (flight,name) =>
{
    flight.RuleName = name;
    flight.Enable = true;
});
/*var ruleEngine = new RulesEngine.RulesEngine(new Workflow[]{workFlow}.ToArray(),reSettings: setting);

foreach (var flight in flights)
{
    var t = await ruleEngine.ExecuteAllRulesAsync("test",
        new RuleParameter("item", flight));
    t.OnSuccess(name =>
    {
        flight.RuleName = name;
        flight.Enable = true;
    });
}*/


Console.WriteLine($"enabled items: {flights.Count(c=>c.Enable)}" );