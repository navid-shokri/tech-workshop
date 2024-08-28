using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Extensions;

namespace AuthorizationSample.API;

public class AttributedEnumConvertor : JsonConverter<Enum>
{
    public override Enum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        
        var attibuteType = typeof(EnumMemberAttribute);
        var value = reader.GetString();
        var attribute = typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(x => x.IsDefined(attibuteType, false))
            .FirstOrDefault(x => x.Attributes.GetAttributeOfType<EnumMemberAttribute>().Value == value);
        return Weather.Cloudy;

    }

    public override void Write(Utf8JsonWriter writer, Enum value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}

