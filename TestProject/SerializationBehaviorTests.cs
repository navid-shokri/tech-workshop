using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using GeoCoordinatePortable;
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


    [Fact]
    public void test3()
    {
        var n = new Person { Name = "Navid", Family = "shokri", Id = Guid.NewGuid() };
        var n1 = new Person { Name = "Navid", Family = "shokriz", Id = Guid.NewGuid() };
        var o = new List<Person> {n, n1 };
        var a = new Person { Name = "Ali", Family = "Darvish", Id = Guid.NewGuid() };
        var b = new Person { Name = "Bita", Family = "Hoseynkhani", Id = Guid.NewGuid() };
        var o1 = new List<Person> {a, b };

        var t = o.Union(o1);
        
        Assert.True(t.Count()==4);
        
    }

    [Fact]
    public void an()
    {
        var o = new GeoCoordinate(35.773201010473365,51.43544002089096);
        var S = new GeoCoordinate(35.7733658457994,51.43112200000003);
        var g = S.GetDistanceTo(o);
        Assert.Equal(g, 10);
    }

    [Fact]
    public void test5()
    {
        var span = TimeSpan.FromMilliseconds(123456);
        var t = span.TotalSeconds.ToString("0.000", CultureInfo.InvariantCulture);
        Assert.Equal("123.456", t);
    }
    
    [Fact]
        public void Asghar()
        {
            var x = AnAgha(0, 0);
            var p = x.Value.x1 + 6;
        }
    
        public (double x1, double x2)? AnAgha(int x1, int x2)
        {
            if (x1 == 0 || x2 == 0)
            {
                return null;
            }
    
            return (1, 4);
        }

        [Fact]
        public void oooo()
        {
            var c = new c()
            {
                bs = new List<b>
                {
                    new b()
                    {
                        name = "b1",
                        a_s = new List<a>
                        {
                            new a()
                            {
                                Date = DateTime.Today.AddDays(7),
                            },
                            new a()
                            {
                                Date = DateTime.Today.AddDays(2),
                            },
                            new a()
                            {
                                Date = DateTime.Today.AddDays(-1),
                            }
                        }
                    },
                    new b()
                    {
                        name = "b2",
                        a_s = new List<a>
                        {
                            new a()
                            {
                                Date = DateTime.Today,
                            },
                            new a()
                            {
                                Date = DateTime.Today.AddDays(4),
                            },
                            new a()
                            {
                                Date = DateTime.Today.AddDays(-2),
                            }
                        }
                    },
                    new b()
                    {
                        name = "b3",
                        a_s = new List<a>
                        {
                            new a()
                            {
                                Date = DateTime.Today.AddDays(10),
                            },
                            new a()
                            {
                                Date = DateTime.Today.AddDays(3),
                            },
                            new a()
                            {
                                Date = DateTime.Today.AddDays(-4),
                            }
                        }
                    }
                }
            };
            var ff = c.bs.First();
            c.bs.Sort((x, y) => DateTime.Compare(x.a_s.MinBy(t=>t.Date).Date,y.a_s.MinBy(t=>t.Date).Date));
            var e = c.bs.First();
            Assert.False(e.name != ff.name);
        }

        class a
        {
            public DateTime Date { get; set; }
        }

        class b
        {
            public string name { get; set; }
            public List<a> a_s { get; set; }
        }

        class c
        {
            public List<b> bs { get; set; }
        }

}