namespace RE.HelperFunctions;

public static class CustomRuleFilter
{
    public static bool CheckContains(string check, string valList)
    {
        if (String.IsNullOrEmpty(check) || String.IsNullOrEmpty(valList))
            return false;

        var list = valList.Split(',',StringSplitOptions.TrimEntries|StringSplitOptions.RemoveEmptyEntries).ToList();
        return list.Contains(check);
    }
}