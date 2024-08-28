using System.Runtime.CompilerServices;
using System.Text.Json;
using MapsterIntro;

namespace TestProject;

public class UnitTest1
{
/*    [Fact]
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

    [Fact]
    public void test()
    {
        var t = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        Assert.Equal(t, "Testing");
    }

    [Fact]
    public Task Test1()
    {
        //https://www.literotica.com/s/my-swap-with-mom-ch-03
        
        try
        {
            Amadeus amadeus = Amadeus
                .builder("REPLACE_BY_YOUR_API_KEY", "REPLACE_BY_YOUR_API_SECRET")
                .build();

            Console.WriteLine("Get Check-in links:");
            CheckinLink[] checkinLinks = amadeus.referenceData.urls.checkinLinks.get(Params
                .with("airlineCode", "BA"));

            Console.WriteLine(checkinLinks[0].response.data);

        }
        catch (Exception e)
        {
            Console.WriteLine("ERROR: " + e.ToString());
        }
    }*/

    [Fact]
    public void test()
    {
        var containers = new List<Container>
        {
            new Container
            {
                Name = nameof(Math.Min),
                Content = new List<Content>()
                {
                    new Content{Departure = DateTime.Now.AddDays(2)},
                    new Content{Departure = DateTime.Now.AddDays(5)},
                }
            }, 
            new Container
            {
                Name = nameof(Math.Max),
                Content = new List<Content>
                {
                    new Content{Departure = DateTime.Now.AddDays(7)},
                    new Content{Departure = DateTime.Now.AddDays(3)}
                }
            }
        };

        var min = containers.MinBy(x => x.Content.MinBy(y => y.Departure));
        var t = min.Name;
    }

    [Fact]
    public void test1()
    {
        var list = new List<Person>()
        {
            new Person{Name = "test1", Family = "testii", Id = Guid.NewGuid()},
            new Person{Name = "test2", Family = "testipoor", Id = Guid.NewGuid()},
            //new Person{Name = "Bita", Family = "Hoseynkhani", Id = Guid.NewGuid()},
        };
        var list1 = new List<Person>()
        {
            new Person{Name = "test1", Family = "testii", Id = Guid.NewGuid()},
            new Person{Name = "test2", Family = "testipoor", Id = Guid.NewGuid()},
        };

        var e = list.Except(list1).ToList();
        var e1 = list1.Except(list).ToList();
        Assert.Empty(e1);
        Assert.Empty(e);
        
    }

    [Fact]
    public void test2()
    {
        var n = new Person { Name = "Navid", Family = "shokri", Id = Guid.NewGuid() };
        var n1 = new Person { Name = "Navid", Family = "shokri", Id = Guid.NewGuid() };
        var a = new Person { Name = "Ali", Family = "Darvish", Id = Guid.NewGuid() };
        var b = new Person { Name = "Bita", Family = "Hoseynkhani", Id = Guid.NewGuid() };

        Assert.True(n == n1);
        Assert.False(n == a);
        Assert.False(n == b);
        
     
    }
}