using System.ComponentModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace MapsterIntro;

public static class EnumExtensions
{
    public static string? GetStringValue<T>(this T enumVal) where T:Enum
    {
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());
        var value = memInfo[0].GetCustomAttributes<EnumMemberAttribute>( false).FirstOrDefault()?.Value;
        if (string.IsNullOrWhiteSpace(value))
        {
            value = memInfo[0].GetCustomAttributes<DescriptionAttribute>( false).FirstOrDefault()?.Description;
        }

        if (string.IsNullOrWhiteSpace(value))
            value = Enum.GetName(type,enumVal);

        return value;
    }
    

    public static T? GetEnumValue<T>(this string value) where T: Enum
    {
        var fieldInfo =typeof(T).GetFields().FirstOrDefault(x => x.GetCustomAttributes<EnumMemberAttribute>().FirstOrDefault()?.Value == value);
        if (fieldInfo == null)
            fieldInfo =typeof(T).GetFields().FirstOrDefault(x => x.GetCustomAttributes<DescriptionAttribute>().FirstOrDefault()?.Description == value);
        if (fieldInfo == null)
            fieldInfo = typeof(T).GetFields().FirstOrDefault(x =>
                x.Name == value);
        if (fieldInfo != null )
            return (T)fieldInfo.GetValue(null);

        return default;
    }
    
    
}