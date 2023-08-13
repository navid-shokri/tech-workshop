using System.Security.Cryptography;
using Mapster;

namespace MapsterIntro;

public class CodeRegistration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ModelSource, ModelDestination>()
            .Map(dest => dest.Family, src => src.Person.Family)
            .Map(dest => dest.Name, src => src.Person.Name)
            .Map(dest => dest.Mark, src => src.EducationInfo.Mark)
            .Map(dest => dest.Grade, src => src.EducationInfo.Grade)
            .Map(dest => dest.CourseNames, src => src.Courses.Select(x=>x.CourseTitle))
            .Map(dest => dest.Instructor, src => src.Teacher)
            .Map(dest => dest.DocInfo.SSId, src => src.NationalId)
            .Map(dest => dest.DocInfo.IssuedIn, src => src.IssuePlace)
            .IgnoreNullValues(true);

        config.NewConfig<Teacher, Instructor>()
            .Map(dest => dest.FirstName, src => src.Name)
            .Map(dest => dest.LastName, src => src.Family);
    }
}