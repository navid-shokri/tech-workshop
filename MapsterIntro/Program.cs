// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Mapster;
using MapsterIntro;

TypeAdapterConfig.GlobalSettings.Scan(AppDomain.CurrentDomain.GetAssemblies());
var rq = new request
{
    Weather = "Sunny",
    Temp = 20
};

//var h = rq.Weather.GetEnumByAttributeValue<Weather>();
var c = rq.Adapt<command>();
var r = c.Adapt<request>();
Console.WriteLine(c.Temp);
/*var start1 = Stopwatch.StartNew();
var t1 = RandomsString();
var t2 = RandomPow();

//var t = await Task.WhenAll(t2, t1).ContinueWith().Unwrap();
start1.Stop();
//Console.WriteLine("1:" +start1.Elapsed.TotalSeconds);
//Console.WriteLine($"Final Result id {t}");
async Task<int> RandomBase()
{
    await Task.Delay(4000);
    Console.WriteLine("salam");
    return new Random().Next(0,5);
}

async Task<string> RandomsString()
{
    await Task.Delay(6000);
    return "abc";
}

async Task<string> CalcString(int times, string str)
{
    await Task.Delay(2500);
    for (int i = 0; i < times; i++)
    {
        str+=str;
    }

    return str;
}

async Task<int> RandomPow()
{
    await Task.Delay(2000);
    Console.WriteLine("Chetori");
    return new Random().Next(0,4);
}

async Task<double> Calculate(params int[] nums)
{
    await Task.Delay(3000);
    Console.WriteLine($"params where: {nums[0]}, {nums[1]} ");
    return Math.Pow(nums[0], nums[1]);
}


/*
/*
Console.WriteLine("Hello, World!");

var f = Flight.GetBuilder()
    .SetBaseInfo("", "", DateTime.Now, "")
    .Build();

var t111 = Flight.GetBuilder().SetBaseInfo("", "", DateTime.Now, "")
    .SetPricing(1000, 750, 400).Build();
    #2#

var listp = new List<Person<int>>
{
    new Person<int>{ Name = "Navid", Family = "Shokri", BirthDay = DateTime.Now.Date.AddYears(35)},
    new Person<int>{ Name = "Vahid", Family = "Shokri", BirthDay = DateTime.Now.Date.AddYears(37)}
};

var o = listp.Adapt<List<PersonDto>>();

Console.WriteLine(o.Count);

//var flightList = new FlightBuilder().Generate(20);

// group by multiple properties
//var groups = flightList.GroupBy(x => new { x.FlightNo, x.Origin, x.Destination, x.DepartureDate.Date });

// group by substring
/*var groups2 = flightList.GroupBy(x =>
{
    var index = $"{x.Origin}:{x.Destination}:{x.DepartureDate:yyyyMMdd}:".Length;
    return x.FlightUID().Substring(0, index);
});#2#
/*var ti9 = DateTime.ParseExact("20191015", "yyyyMMdd", new DateTimeFormatInfo());
var t = new ModelSource();
t.AssertNullOrEmpty(obj => obj.NationalId);

var src = new ModelSource
{
    NationalId = "5309986391",
    IssuePlace = "Shahmirzad",
    Person = new PersonInfo
    {
        Name = "Navid",
        Family = "Shokri"
    },
    EducationInfo = new EducationInfo
    {
        Grade = "bachelor",
        Mark = 20
    },
    Courses = new List<Course>
    {
        new Course{CourseId = 1, CourseTitle = "advance programming"},
        new Course{CourseId = 2, CourseTitle = "data structure"}

    },
    Teacher = new Teacher
    {
        Family = "Vahedi",
        Name = "Mohamad Ali"
    },
    BestFriendName = "saeed salavati"
};

var dst = src.Adapt<ModelDestination>();


Console.WriteLine($"--{dst.Family} {dst.Name}--");
Console.WriteLine($"--{string.Join("-", dst.CourseNames)}--");
Console.WriteLine($"**{ dst.DocInfo.SSId} {dst.DocInfo.IssuedIn}**");
Console.WriteLine($"**{ dst.Instructor.FirstName} {dst.Instructor.LastName}**");
Console.WriteLine($"++{dst.BestFriendName}++");#2#

/*var persons = new List<Person>
{
  new Person{Name = "navid", Family = "shokri", BirthDay = new DateTime(1988,9,8)},
  new Person{Name = "behrad", Family = "shokri", BirthDay = new DateTime(2020,7,10)},
  new Person{Name = "ali", Family = "shokri", BirthDay = new DateTime(1988,4,26)}
};

var personDtos = persons.Adapt<List<PersonDto>>() ;#2#

List<Teacher> teachers = new List<Teacher>
{
    new Teacher{ Name = "Fateme", Family = "tolooei", CourseId = 1 , Course = new Course { Id = 1,  Title = "graphic design"},},
    new Teacher{ Name = "Mansoore", Family = "Shamani",CourseId = 2, Course =  new Course { Id = 2,  Title = "Biology"}},
    new Teacher{Name = "mohtaram", Family = "Forati", CourseId = 3 ,Course = new Course { Id = 3,  Title = "Basic"}},
    new Teacher{Name = "ghazal", Family = "mahdavi", CourseId = 4, Course = new Course { Id = 4,  Title = "Litrature"},}
};
var t = teachers.Adapt<List<CourseView>>();
/*List<Course> courses = new List<Course>
{
 new Course { Id = 1,  Title = "graphic design"},
 new Course { Id = 2,  Title = "Biology"},
 new Course { Id = 3,  Title = "Basic"},
};


var yy = teachers.Zip(courses);
var tt = teachers.Join(courses, teacher => teacher.CourseId, course => course.Id, (teacher, course) => new
{
    TeacherName = $"{teacher.Name} {teacher.Family}",
    course = course.Title
});

Console.WriteLine(tt.First().TeacherName);
Console.WriteLine(yy.First().First.Family);

var p = new Person<Guid>
{
    Family = "salavati",
    Name = "saeed", Id = Guid.NewGuid(),
    BirthDay = DateTime.Now.AddYears(-20)
};

var t = new Teacher
{
    Name = "Saeed",
    Family = "Salamati",
    CourseId = 5
};

//Console.WriteLine(getType(p));
Console.WriteLine(p.Family);
if (true) { Console.WriteLine("test"); }

public class CourseView
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string CourseTitle { get; set; }
}#1#
*/
