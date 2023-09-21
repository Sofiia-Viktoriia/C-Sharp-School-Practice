namespace ToolsQAProject.Entities
{
    public class StudentRegistrationForm
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string MobilePhone { get; set; }
        public string DateOfBirth { get; set; }
        public List<string> Subjects { get; set; }
        public List<string> Hobbies { get; set; }
        public string CurrentAddress { get; set; }
        public string State { get; set; }
        public string City { get; set; }
    }
}
