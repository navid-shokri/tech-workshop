using System.Text.Json;

namespace TestProject;

public class JsonTest
{
    [Fact]
    public async void MethodName()
    {
        //arrange
        var str = @"{""fullName"":""Navid"", ""age"" : 38, ""address"":{ ""street"":""Chaharmeydan"", ""number"": 100}}";
        var option = new JsonSerializerOptions
        {
            Converters = { new PrivateSetterConverter<ManKind>(), new PrivateSetterConverter<NewAddress>()  }
        };
        //action

        var t = JsonSerializer.Deserialize<ManKind>(str, option);
        //assert
        Assert.Equal(t.FullName, "Navid");
    }

    
}