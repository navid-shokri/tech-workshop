using Bogus;
using MapsterIntro;

namespace TestProject;

public class StudentBuilder : Faker<Student>
{
    public StudentBuilder()
    {
        this.Rules((faker, student) =>
        {
            student.Name = faker.Name.FirstName();
            student.Family = faker.Name.LastName();
        });
    }

}