using System.Reflection;
using System.Runtime.Serialization;
using Bogus;
using Mapster;

namespace MapsterIntro;

public class CodeRegistration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<request, command>()
            .Map(dest => dest.Weather, src => src.Weather.GetEnumValue<Weather>())
            .Map(dst => dst.Temp, src=>src.Temp)
            .IgnoreNullValues(true);
        
        
        config.NewConfig<command, request >()
            .Map(dest => dest.Weather, src => src.Weather.GetStringValue())
            .Map(dst => dst.Temp, src=>src.Temp)
            .IgnoreNullValues(true);
        
        
        config.NewConfig<ModelSource, ModelDestination>()
            .Map(dest => dest.Family, src => src.Person.Family)
            .Map(dest => dest.Name, src => src.Person.Name)
            .Map(dest => dest.Mark, src => src.EducationInfo.Mark)
            .Map(dest => dest.Grade, src => src.EducationInfo.Grade)
            .Map(dest => dest.CourseNames, src => src.Courses.Select(x=>x.Title))
            .Map(dest => dest.Instructor, src => src.Teacher)
            .Map(dest => dest.DocInfo.SSId, src => src.NationalId)
            .Map(dest => dest.DocInfo.IssuedIn, src => src.IssuePlace)
            .IgnoreNullValues(true);

        config.NewConfig<Teacher, Instructor>()
            .Map(dest => dest.FirstName, src => src.Name)
            .Map(dest => dest.LastName, src => src.Family);

        config.NewConfig<command, List<Person>>()
            .Map(dest => dest, command => an(command)
           );


    }

    private List<Person> an(command com)
    {
        return Enumerable.Range(0, com.Temp).Select(x => new Person
        {
            FirstName = "Name" + x
        }).ToList();
    }

    private T ConvertStringToEnum<T>(string value) where T : Enum{
        var a =typeof(T).GetFields().FirstOrDefault(x => x.GetCustomAttributes<EnumMemberAttribute>().FirstOrDefault()?.Value == value);
        if (a == null)
            a = typeof(T).GetFields().FirstOrDefault(x =>
                x.Name == value);
        if (a != null )
            return (T)a.GetValue(null);

        return default;
    }

    
}