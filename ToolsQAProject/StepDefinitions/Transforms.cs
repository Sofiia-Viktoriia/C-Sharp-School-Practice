using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using ToolsQAProject.Entities;

namespace ToolsQAProject.StepDefinitions
{
    [Binding]
    public class Transforms
    {
        [StepArgumentTransformation]
        public string[] StringValuesTransform(Table table)
        {
            return table.Rows.Select(r => r[0]).ToArray();
        }

        [StepArgumentTransformation(@"user selects squares")]
        public int[] SquaresNumbersTransform(Table table)
        {
            return table.Rows.Select(r => int.Parse(r[0])).ToArray();
        }

        [StepArgumentTransformation]
        public StudentRegistrationForm StudentRegistrationFormTransform(Table table)
        {
            return new StudentRegistrationForm
            {
                FirstName = table.Rows[0]["FirstName"],
                LastName = table.Rows[0]["LastName"],
                Email = table.Rows[0]["Email"],
                Gender = table.Rows[0]["Gender"],
                MobilePhone = table.Rows[0]["MobilePhone"],
                DateOfBirth = table.Rows[0]["DateOfBirth"],
                Subjects = table.Rows[0]["Subjects"].Split("; ").ToList(),
                Hobbies = table.Rows[0]["Hobbies"].Split("; ").ToList(),
                CurrentAddress = table.Rows[0]["CurrentAddress"],
                State = table.Rows[0]["State"],
                City = table.Rows[0]["City"]
            };
        }

        [StepArgumentTransformation]
        public UserForm UserFormTransform(Table table)
        {
            return table.CreateInstance<UserForm>();
        }
    }
}
