// See https://aka.ms/new-console-template for more information

using Mapster;
using MapsterIntro;

TypeAdapterConfig.GlobalSettings.Scan(AppDomain.CurrentDomain.GetAssemblies());
Console.WriteLine("Hello, World!");
var test = new FlightBuilder().Generate(5);
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