using System.Security.Cryptography;

namespace MapsterIntro;

public class ModelSource
{
    public PersonInfo Person { get; set; }
    public EducationInfo EducationInfo { get; set; }
    public List<Course> Courses { get; set; }
    public Teacher Teacher { get; set; }
    public string IssuePlace { get; set; }
    public string NationalId { get; set; }
    public string BestFriendName { get; set; }
}

public class PersonInfo
{
    public string Name { get; set; }
    public string Family { get; set; }
    
}

public class Course
{
    public string CourseTitle { get; set; }
    public int CourseId { get; set; }
}

public class EducationInfo
{
    public int Mark { get; set; }
    public string Grade { get; set; }
}

public class Teacher
{
    public string Name { get; set; }
    public string Family { get; set; }
}