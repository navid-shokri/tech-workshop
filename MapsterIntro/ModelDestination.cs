using System.Linq.Expressions;

namespace MapsterIntro;

public class ModelDestination
{
    public string Name { get; set; }
    public string Family { get; set; }
    public float Mark { get; set; }
    public string Grade { get; set; }
    public List<string> CourseNames { get; set; }
    public Instructor Instructor { get; set; }
    public DocInfo DocInfo { get; set; }
    public string BestFriendName { get; set; }
}

public class Instructor{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class DocInfo
{
    public string IssuedIn { get; set; }
    public string SSId { get; set; }
}

public static class Extensions 
{
    public static void AssertNullOrEmpty<T>(this T instance, Expression<Func<T, string>> property) where T :class
    {
        if (string.IsNullOrEmpty(property.Compile().Invoke(instance)))
        {
            throw new InvalidOperationException($"{GetMemberName(property)} should not be null");
        }
    }

    private static string GetMemberName(Expression expression)
    {
        MemberExpression mem = GetMemberInfo(expression);
        if (expression == null)
        {
            throw new ArgumentException("expressionCannotBeNullMessage");
        }

        // Reference type property or field
        return mem.Member.Name;

    }

    private static MemberExpression GetMemberInfo(Expression method)
    {
        LambdaExpression lambda = method as LambdaExpression;
        if (lambda == null)
            throw new ArgumentNullException("method");

        MemberExpression memberExpr = null;

        if (lambda.Body.NodeType == ExpressionType.Convert)
        {
            memberExpr = 
                ((UnaryExpression)lambda.Body).Operand as MemberExpression;
        }
        else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
        {
            memberExpr = lambda.Body as MemberExpression;
        }

        if (memberExpr == null)
            throw new ArgumentException("method");

        return memberExpr;
    }
}