namespace TestProject;

using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

public class PrivateSetterConverter<T> : JsonConverter<T> where T : class
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException("Expected object start");

        // Create uninitialized object without calling constructor
        var instance = (T)FormatterServices.GetUninitializedObject(typeof(T));
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
                return instance;

            if (reader.TokenType == JsonTokenType.PropertyName)
            {
                string propertyName = reader.GetString();
                reader.Read(); // Move to property value

                // Find matching property (case-insensitive)
                var property = Array.Find(properties, 
                    p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

                if (property != null && property.CanWrite)
                {
                    object value = ExtractValue(ref reader, property.PropertyType, options);
                    property.SetValue(instance, value);
                }
                else
                {
                    reader.Skip(); // Skip unknown properties
                }
            }
        }

        throw new JsonException("Unexpected end of JSON");
    }

    private object ExtractValue(ref Utf8JsonReader reader, Type targetType, JsonSerializerOptions options)
    {
        try
        {
            // Use JsonSerializer for complex types
            if (reader.TokenType == JsonTokenType.StartObject || 
                reader.TokenType == JsonTokenType.StartArray)
            {
                return JsonSerializer.Deserialize(ref reader, targetType, options);
            }

            // Handle basic types
            switch (Type.GetTypeCode(targetType))
            {
                case TypeCode.String:
                    return reader.GetString();
                case TypeCode.Int32:
                    return reader.GetInt32();
                case TypeCode.Int64:
                    return reader.GetInt64();
                case TypeCode.Double:
                    return reader.GetDouble();
                case TypeCode.Decimal:
                    return reader.GetDecimal();
                case TypeCode.Boolean:
                    return reader.GetBoolean();
                case TypeCode.DateTime:
                    return reader.GetDateTime();
                default:
                    // For other types, try to convert from string
                    if (reader.TokenType == JsonTokenType.String)
                    {
                        string stringValue = reader.GetString();
                        return Convert.ChangeType(stringValue, targetType);
                    }
                    // For numbers, try to convert
                    else if (reader.TokenType == JsonTokenType.Number)
                    {
                        // Try to get the value as decimal and convert
                        decimal decimalValue = reader.GetDecimal();
                        return Convert.ChangeType(decimalValue, targetType);
                    }
                    else
                    {
                        reader.Skip();
                        return null;
                    }
            }
        }
        catch (Exception ex)
        {
            throw new JsonException($"Error converting value for type {targetType.Name}", ex);
        }
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            if (property.CanRead)
            {
                writer.WritePropertyName(property.Name);
                var propertyValue = property.GetValue(value);
                JsonSerializer.Serialize(writer, propertyValue, options);
            }
        }
        
        writer.WriteEndObject();
    }
}