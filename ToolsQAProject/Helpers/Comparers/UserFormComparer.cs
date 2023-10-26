using System.Diagnostics.CodeAnalysis;
using ToolsQAProject.Entities;

namespace ToolsQAProject.Helpers.Comparers
{
    public class UserFormComparer : IEqualityComparer<UserForm>
    {
        public bool Equals(UserForm? x, UserForm? y)
        {
            return (x is null && y is null) || GetHashCode(x) == GetHashCode(y);
        }

        public int GetHashCode([DisallowNull] UserForm obj)
        {
            return $"{obj.FullName}-{obj.Email}-{obj.CurrentAddress}-{obj.PermanentAddress}".GetHashCode();
        }
    }
}
