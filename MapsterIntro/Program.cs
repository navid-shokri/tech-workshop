// See https://aka.ms/new-console-template for more information

using System.Globalization;
using System.Text.RegularExpressions;
using Mapster;
using MapsterIntro;

TypeAdapterConfig.GlobalSettings.Scan(AppDomain.CurrentDomain.GetAssemblies());
Console.WriteLine("Hello, World!");
//var flightList = new FlightBuilder().Generate(20);

// group by multiple properties 
//var groups = flightList.GroupBy(x => new { x.FlightNo, x.Origin, x.Destination, x.DepartureDate.Date });

// group by substring 
/*var groups2 = flightList.GroupBy(x =>
{
    var index = $"{x.Origin}:{x.Destination}:{x.DepartureDate:yyyyMMdd}:".Length;
    return x.FlightUID().Substring(0, index);
});*/
var ti9 = DateTime.ParseExact("20191015", "yyyyMMdd", new DateTimeFormatInfo());
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
Console.WriteLine($"++{dst.BestFriendName}++");