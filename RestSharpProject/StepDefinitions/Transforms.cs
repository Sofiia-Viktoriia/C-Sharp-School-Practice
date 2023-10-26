using RestSharpProject.Models.Reqres;
using TechTalk.SpecFlow.Assist;

namespace RestSharpProject.StepDefinitions
{
    [Binding]
    public class Transforms
    {
        [StepArgumentTransformation]
        public CreateUpdateUserBody CreateUpdateUserBodyTransform(Table table)
        {
            return table.CreateInstance<CreateUpdateUserBody>();
        }

        [StepArgumentTransformation]
        public LoginRegistrationBody LoginRegistrationBodyTransform(Table table)
        {
            return table.CreateInstance<LoginRegistrationBody>();
        }
    }
}
