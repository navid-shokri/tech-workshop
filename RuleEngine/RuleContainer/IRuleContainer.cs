using RulesEngine.Models;

namespace TestRuleEngine;

public interface IRuleContainer
{
    Rule ComposeRule();
}