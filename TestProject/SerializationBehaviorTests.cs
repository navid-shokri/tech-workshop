using System.Text.Json;
using MapsterIntro;

namespace TestProject;

public class UnitTest1
{
    [Fact]
    public void PrivatePropertyWithDefaultValueProvider()
    {
        //arrange
        var actual = new StudentBuilder().Generate();
        var serialized = JsonSerializer.Serialize(actual);
        
        //act
        var expected = JsonSerializer.Deserialize<Student>(serialized);
        
        //expected
        Assert.NotEqual(expected.Id, actual.Id);
        Assert.Equal(expected.Name, actual.Name);
        Assert.Equal(expected.Family, actual.Family);

    }
}