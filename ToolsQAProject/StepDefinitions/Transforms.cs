using System.Globalization;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToolsQAProject.Entities;

namespace ToolsQAProject.StepDefinitions
{
    [Binding]
    public class Transforms
    {
        [StepArgumentTransformation]
        public string[] TableToStringArray(Table table)
        {
            return table.Rows.Select(r => r[0]).ToArray();
        }

        [StepArgumentTransformation]
        public int[] TableToIntArray(Table table)
        {
            return table.Rows.Select(r => int.Parse(r[0])).ToArray();
        }

        [StepArgumentTransformation]
        public StudentRegistrationForm TableToStudentRegistrationForm(Table table)
        {
            return table.CreateInstance<StudentRegistrationForm>();
        }

        [StepArgumentTransformation]
        public UserForm TableToUserForm(Table table)
        {
            return table.CreateInstance<UserForm>();
        }
    }
}
