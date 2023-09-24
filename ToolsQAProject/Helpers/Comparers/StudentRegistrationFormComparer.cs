using System.Diagnostics.CodeAnalysis;
using ToolsQAProject.Entities;

namespace ToolsQAProject.Helpers.Comparers
{
    public class StudentRegistrationFormComparer : IEqualityComparer<StudentRegistrationForm>
    {
        public bool Equals(StudentRegistrationForm? x, StudentRegistrationForm? y)
        {
            return (x is null && y is null) || GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode([DisallowNull] StudentRegistrationForm obj)
        {
            return $"{obj.FirstName}-{obj.LastName}-{obj.Email}-{obj.Gender}-{obj.MobilePhone}-{obj.DateOfBirth}-{obj.Subjects}-{obj.Hobbies}-{obj.CurrentAddress}-{obj.State}-{obj.City}"
                .GetHashCode();
        }
    }
}
